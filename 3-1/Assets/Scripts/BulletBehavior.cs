using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    public bool hasCollided = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Translate(Vector3.up * .8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
