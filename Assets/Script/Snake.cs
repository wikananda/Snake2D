using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    enum State
    {
        Normal,
        Pause,
        GameOver
    }
    State state;
    [SerializeField] GameObject segment;
    [SerializeField] Rigidbody2D rigid;
    List<GameObject> snakeSegments;
    Vector2 dir;
    Vector2 lastDir;
    Vector3 targetPos;
    [SerializeField] ScoreManager manageScore;

    void Start()
    {
        state = State.Normal;
        dir = Vector2.right;
        lastDir = dir;
        snakeSegments = new List<GameObject>();
        snakeSegments.Add(gameObject);
    }

    private void Update()
    {
        Control();
        switch (state)
        {
            case State.GameOver:
                manageScore.FinalResult();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ResetGame();
                    Debug.Log("Reset");
                }
                return;
            case State.Pause:
                manageScore.Pause();
                break;
            case State.Normal:
                manageScore.Unpause();
                break;

        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
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
                break;
        }

    }

    void Control()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Vector2.up == -lastDir) return;
            dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Vector2.down == -lastDir) return;
            dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Vector2.left == -lastDir) return;
            dir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Vector2.right == -lastDir) return;
            dir = Vector2.right;
        }
        lastDir = dir;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == State.Pause)
            {
                state = State.Normal;
                return;
            }
            if (state == State.GameOver)
            {
                return;
            }
            state = State.Pause;
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
            state = State.GameOver;
        }
    }

    public void ResetGame()
    {
        state = State.Normal;
        for (int i = 1; i < snakeSegments.Count; i++)
        {
            Destroy(snakeSegments[i]);
        }
        snakeSegments.Clear();
        gameObject.transform.position = Vector3.zero - new Vector3(9, 0, 0);
        snakeSegments.Add(gameObject);
        manageScore.ResetScore();
        manageScore.QuitResult();
    }

    void Grow()
    {
        snakeSegments.Add(Instantiate(segment, transform.position, Quaternion.identity));
        manageScore.ScoreUp();
    }
}
