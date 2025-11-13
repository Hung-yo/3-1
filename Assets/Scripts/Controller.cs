using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn pawn;
    public GameManager gameManager;
    public KeyCode shootKey = KeyCode.Space;
    public float shootKeyTime;
    public CameraFocusPoint focusPoint;
    private Shooter shooter;
    public float offsetAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.gameManager;
        pawn = gameManager.pawn;
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.pawn == null || GameManager.isPaused || !GameManager.isGameStarted || GameManager.gameOver)
        {
            return;
        }
        else
        {
            // Move forward/backward
            if (Input.GetKey(KeyCode.W))
            {
                pawn.MoveForward(pawn.moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                pawn.MoveForward(-pawn.moveSpeed);
            }

            // Yaw (rotate around Y axis)
            if (Input.GetKey(KeyCode.A))
            {
                pawn.Yaw(-pawn.rotationSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                pawn.Yaw(pawn.rotationSpeed);
            }

            // Roll (rotate around Z axis)
            if (Input.GetKey(KeyCode.Q))
            {
                pawn.Roll(pawn.rotationSpeed);
            }
            if (Input.GetKey(KeyCode.E))
            {
                pawn.Roll(-pawn.rotationSpeed);
            }

            // Pitch (rotate around X axis)
            if (Input.GetKey(KeyCode.Z))
            {
                pawn.Pitch(pawn.rotationSpeed);
            }
            if (Input.GetKey(KeyCode.X))
            {
                pawn.Pitch(-pawn.rotationSpeed);
            }

            if (Input.GetKey(KeyCode.O))
            {
                focusPoint.ChangeOffset(-offsetAmount);
            }
            if (Input.GetKey(KeyCode.L))
            {
                focusPoint.ChangeOffset(offsetAmount);
            }

            
            if (Input.GetKeyDown(shootKey))
            {
                shootKeyTime = 0f; // Start keeping track of hold time
            }

            if (Input.GetKey(shootKey))
            {
                shootKeyTime += Time.deltaTime; // Increase hold time
            }

            if (Input.GetKeyUp(shootKey))
            {
                if (shootKeyTime >= 1f)
                {
                    shooter.Shoot(2); // Fire big bullet if held for 1 second or more
                }
                else
                {
                    shooter.Shoot(1); // Fire normal bullet if not held down long enough
                }
                shootKeyTime = 0f; // Reset timer
            }
        }
    }
}
