using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] Collider2D arena;
    private void Start()
    {
        SpawnFood();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpawnFood();
            if (other.tag == "Obstacle")
            {
                SpawnFood();
            }
        }
    }

    void SpawnFood()
    {
        Vector3 foodSpawn = new Vector3(
            Mathf.Round(Random.Range(arena.bounds.min.x, arena.bounds.max.x)),
            Mathf.Round(Random.Range(arena.bounds.min.y, arena.bounds.max.y)),
            0
        );

        transform.position = foodSpawn;
    }
}
