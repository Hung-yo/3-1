using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Pawn pawn;
    public float moveSpeed;
    public bool hasCollided = false;
    public Vector3 pointToMoveTowards;
    // public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pawn = GameManager.gameManager.pawn;
        pointToMoveTowards = pawn.transform.position * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn != null && GameManager.isPaused == false && GameManager.isGameStarted && GameManager.gameOver == false)
        {
            MoveTowards(pointToMoveTowards);
        }
    }

    public void MoveTowards(Vector3 pointToMoveTowards)
    {
        // Find vector to that point
        Vector3 moveVector = pointToMoveTowards - transform.position;
        // Normalize it
        moveVector.Normalize();
        // Multiply by speed
        moveVector *= moveSpeed * Time.deltaTime;
        // Move that vector from current position
        transform.position = transform.position + moveVector;
    }

    public void MoveTowards(GameObject objectToMoveTowards)
    {
        MoveTowards(objectToMoveTowards.transform.position);
    }

    public void MoveTowards(Pawn pawnToMoveTowards)
    {
        MoveTowards(pawnToMoveTowards.transform.position);
    }

    public void MoveTowards(Transform transformToMoveTowards)
    {
        MoveTowards(transformToMoveTowards.position);
    }

}
