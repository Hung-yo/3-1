using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject focusPoint;
    public GameObject pawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Default camera position is offset (.06f, 1.9f, -4.56f)
        transform.position = focusPoint.transform.position + pawn.transform.rotation * new Vector3(.06f, 1.9f, -4.56f);
        transform.rotation = focusPoint.transform.rotation;
    }
}
