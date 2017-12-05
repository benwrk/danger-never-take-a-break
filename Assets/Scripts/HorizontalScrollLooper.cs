using UnityEngine;

public class HorizontalScrollLooper : MonoBehaviour
{
    public bool RandomXFlip;

    private void Update()
    {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        if (transform.position.x < -width)
        {
            transform.position = (Vector2) transform.position + new Vector2(width * 2f, 0f);
            if (RandomXFlip && Random.Range(0, 2) > 0)
            {
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}