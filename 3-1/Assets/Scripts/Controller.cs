using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn pawn;
    public GameManager gameManager;
    public KeyCode shootKey = KeyCode.Space;
    public float shootKeyTime;
    private Shooter shooter;
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
            if (Input.GetKey(KeyCode.W)) // Move forwards
            {
                pawn.MoveForward(pawn.moveSpeed);
            }

            if (Input.GetKey(KeyCode.A)) // Rotate counterclockwise
            {
                pawn.Rotate(pawn.rotationSpeed);
            }

            if (Input.GetKey(KeyCode.S)) // Move backwards
            {
                pawn.MoveForward(-1 * pawn.moveSpeed);
            }

            if (Input.GetKey(KeyCode.D)) // Rotate clockwise
            {
                pawn.Rotate(-1 * pawn.rotationSpeed);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) // Translate north
            {
                pawn.TranslateVertically(pawn.worldSpaceSpeed);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Translate west
            {
                pawn.TranslateHorizontally(-1 * pawn.worldSpaceSpeed);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) // Translate south
            {
                pawn.TranslateVertically(-1 * pawn.worldSpaceSpeed);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) // Translate east
            {
                pawn.TranslateHorizontally(pawn.worldSpaceSpeed);
            }

            // Check if pawn is within bounds x -10 to 10, y -5 to 5, teleport them back if necessary
            if (pawn.transform.position.x < -10)
            {
                pawn.TranslateHorizontally(.1f);
            }

            if (pawn.transform.position.x > 10)
            {
                pawn.TranslateHorizontally(-.1f);
            }

            if (pawn.transform.position.y < -5)
            {
                pawn.TranslateVertically(.1f);
            }

            if (pawn.transform.position.y > 5)
            {
                pawn.TranslateVertically(-.1f);
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
