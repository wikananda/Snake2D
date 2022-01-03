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
            if (other.tag == "Obstacle")
            {
                SpawnFood();
            }
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        bool validPos = false;
        Vector2 size = new Vector2(1, 1);
        Vector3 foodSpawn = Vector3.zero;

        while (!validPos)
        {
            foodSpawn = new Vector3(
                Mathf.Round(Random.Range(arena.bounds.min.x, arena.bounds.max.x)),
                Mathf.Round(Random.Range(arena.bounds.min.y, arena.bounds.max.y)),
                0
            );

            validPos = true;
            Collider2D colliders = Physics2D.OverlapBox(foodSpawn, size, 0);
            if (colliders.tag == "Obstacle" || colliders.tag == "Player")
            {
                validPos = false;
            }

        }

        transform.position = foodSpawn;
    }
}
