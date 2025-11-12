using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public KeyCode teleportKey;
    public float teleportRange = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            float randomX = Random.Range(-1 * teleportRange, teleportRange);
            transform.position = new Vector3(randomX, 0, 0);
        }
    }
}
