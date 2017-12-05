using UnityEngine;
using System.Collections.Generic;

public class RoadsidePrefabPool : MonoBehaviour
{
    public GameObject Roadside; //The roadsidePrefab game object.
    public List<GameObject> RoadsidePrefabs;
    public float SpawnRate = 3f; //How quickly roadsidePrefabs spawn.
    public float RoadsidePrefabMin; //Minimum y value of the roadsidePrefab position.
    public float RoadsidePrefabMax; //Maximum y value of the roadsidePrefab position.
    public float RoadsidePrefabMaxScale = 1f; //Maximum y value of the roadsidePrefab position.
    public float RoadsidePrefabMinScale = 1f; //Maximum y value of the roadsidePrefab position.

    private GameObject[] _roadsidePrefabs; //Collection of pooled roadsidePrefabs.
    private int _currentRoadsidePrefab = 0; //Index of the current roadsidePrefab in the collection.

    private static readonly Vector2 ObjectPoolPosition = new Vector2(-15, -25); //A holding position for our unused roadsidePrefabs offscreen.
    public float SpawnXPosition = 10f;

    private float _timeSinceLastSpawned;


    private void Start()
    {
        _timeSinceLastSpawned = 0f;

        //Initialize the roadsidePrefabs collection.
        _roadsidePrefabs = new GameObject[RoadsidePrefabs.Count];
        //Loop through the collection... 
        for (int i = 0; i < RoadsidePrefabs.Count; i++)
        {
            //...and create the individual roadsidePrefabs.
            var go = (GameObject) Instantiate(RoadsidePrefabs[i], ObjectPoolPosition, Quaternion.identity);
            go.transform.parent = Roadside.transform;
            _roadsidePrefabs[i] = go;
        }
    }


    //This spawns roadsidePrefabs as long as the game is not over.
    private void Update()
    {
        _timeSinceLastSpawned += Time.deltaTime;
        var spr = 10 * SpawnRate /(GameController.Instance.GetEffectiveGameSpeed() / GameController.Instance.GameSpeed);

        if (GameController.Instance.State == GameController.GameState.Active && _timeSinceLastSpawned >= spr)
        {
            _timeSinceLastSpawned = 0f;

            //Set a random y position for the roadsidePrefab
            float spawnYPosition = Random.Range(RoadsidePrefabMin, RoadsidePrefabMax);

            //...then set the current roadsidePrefab to that position.
            _roadsidePrefabs[_currentRoadsidePrefab].transform.position = new Vector2(SpawnXPosition, spawnYPosition);

            //Increase the value of currentRoadsidePrefab. If the new size is too big, set it back to zero
            _currentRoadsidePrefab++;

            if (_currentRoadsidePrefab >= RoadsidePrefabs.Count)
            {
                _currentRoadsidePrefab = 0;
            }
        }
    }
}