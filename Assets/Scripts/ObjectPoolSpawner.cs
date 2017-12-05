using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSpawner : MonoBehaviour
{
    private readonly Vector2 _poolLocation = new Vector2(0f, -100f);

    private int _lastSpawnedIndex;

    private List<GameObject> _objectPool;

    private Transform _parentTransform;

    private float _timeSinceLastSpawn;

    public float MaxScale;

    public float MaxSpawnY;

    public float MinScale;

    public float MinSpawnY;

    public uint PoolSizeMultiplier = 1;

    public List<GameObject> Prefabs;

    public bool RandomXFlip;

    public float SpawnInterval = 8f;

    public float SpawnX;

    private void Awake()
    {
        _parentTransform = GetComponent<Transform>();
        _objectPool = new List<GameObject>();
        for (var i = 0; i < PoolSizeMultiplier; i++)
            foreach (var prefab in Prefabs)
                _objectPool.Add(Instantiate(prefab, _poolLocation, Quaternion.identity, _parentTransform));
    }

    private void Update()
    {
        _timeSinceLastSpawn += GameController.Instance.GetEffectiveGameSpeed() * Time.deltaTime;
        if (_timeSinceLastSpawn > SpawnInterval)
            Spawn();
    }

    private void Spawn()
    {
        var go = _objectPool[_lastSpawnedIndex];
        _timeSinceLastSpawn = 0;
        _lastSpawnedIndex = _lastSpawnedIndex + 1 >= _objectPool.Count ? 0 : _lastSpawnedIndex + 1;

        var flipScale = RandomXFlip && Random.Range(0, 2) > 0 ? -1f : 1f;
        var randomScale = Random.Range(MinScale, MaxScale);

        go.transform.position = new Vector3(SpawnX, Random.Range(MinSpawnY, MaxSpawnY), go.transform.position.z);
        go.transform.localScale = new Vector3(flipScale * randomScale, randomScale,
            go.transform.localScale.z);
    }
}