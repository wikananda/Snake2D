using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] GameObject segment;
    [SerializeField] Rigidbody2D rigid;
    List<GameObject> snakeSegments;

    Vector2 dir = Vector2.right;
    Vector3 targetPos;

    void Start()
    {
        snakeSegments = new List<GameObject>();
        snakeSegments.Add(gameObject);
    }

    private void Update()
    {
        Control();
    }

    private void FixedUpdate()
    {
        for (int i = snakeSegments.Count - 1; i > 0; i--)
        {
            snakeSegments[i].transform.position = snakeSegments[i - 1].transform.position;
        }
        targetPos = new Vector3(
            transform.position.x + dir.x,
            transform.position.y + dir.y,
            0
        );
        transform.position = targetPos;
    }

    void Control()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        for (int i = 1; i < snakeSegments.Count; i++)
        {
            Destroy(snakeSegments[i]);
        }
        snakeSegments.Clear();
        gameObject.transform.position = Vector3.zero - new Vector3(9, 0, 0);
        snakeSegments.Add(gameObject);
    }

    void Grow()
    {
        snakeSegments.Add(Instantiate(segment, transform.position, Quaternion.identity));
    }
}
