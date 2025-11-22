using UnityEngine;

public class AstronautBehavior : MonoBehaviour
{
    public float rotationSpeed;
    public float bobbingSpeed;
    private float yInitial;
    public float amplitude;
    void Start()
    {
        yInitial = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        // Spin around slowly
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        // Bob up and down slowly
        Vector3 pos = transform.position;
        pos.y = yInitial + Mathf.Sin(Time.time * bobbingSpeed) * amplitude;
        transform.position = pos;

    }
}
