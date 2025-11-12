using UnityEngine;

public class MeteorFragment : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // pick a random direction
        direction = Random.insideUnitCircle.normalized;
    }


    // Update is called once per frame
    void Update()
    {
        // Move in the direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
