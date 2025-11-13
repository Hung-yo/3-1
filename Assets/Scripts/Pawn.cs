using Unity.VisualScripting;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Movement")]
    public float baseSpeed;
    public float moveSpeed;
    public float rotationSpeed;
    public float worldSpaceSpeed;
    public Rigidbody rigidBody;

    [Header("Health")]
    public Health health;
    public Death death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
        death = GetComponent<Death>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = baseSpeed * 2;
        }
        else
        {
            moveSpeed = baseSpeed;
        }
    }

    public void MoveForward(float moveSpeed)
    {
        rigidBody.AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
    }

    public void Rotate(float rotationSpeed)
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void Yaw(float rotationSpeed)
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void Pitch(float rotationSpeed)
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void Roll(float rotationSpeed)
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void TranslateHorizontally(float worldSpaceSpeed)
    {
        transform.Translate(Vector3.right * worldSpaceSpeed, Space.World);
    }
    public void TranslateVertically(float worldSpaceSpeed)
    {
        transform.Translate(Vector3.up * worldSpaceSpeed, Space.World);
    }
}