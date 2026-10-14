
using UnityEngine;

public class TrafficGame : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float smoothSpeed = 10f;

    [Header("Road")]
    public float leftLimit = -3f;
    public float rightLimit = 3f;

    private float targetX;
    private int score;

    private void Start()
    {
        targetX = transform.position.x;
    }

    private void Update()
    {
        float direction = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            direction = 1f;

        targetX += direction * moveSpeed * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, leftLimit, rightLimit);

        Vector3 position = transform.position;
        position.x = Mathf.Lerp(
            position.x,
            targetX,
            smoothSpeed * Time.deltaTime
        );

        transform.position = position;
    }

    public void MoveLeft()
    {
        targetX -= moveSpeed;
        targetX = Mathf.Clamp(targetX, leftLimit, rightLimit);
    }

    public void MoveRight()
    {
        targetX += moveSpeed;
        targetX = Mathf.Clamp(targetX, leftLimit, rightLimit);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
