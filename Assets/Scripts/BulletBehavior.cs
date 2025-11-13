using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    public bool hasCollided = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Translate(Vector3.forward * 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
