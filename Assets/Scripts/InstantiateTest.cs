using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
    public GameObject objectToCopy;
    public Controller controllerToConnect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject tempPawn;
            tempPawn = Instantiate(objectToCopy, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            if (controllerToConnect != null)
            {
                Pawn pawnComponent = tempPawn.GetComponent<Pawn>();
                if (pawnComponent != null)
                {
                    controllerToConnect.pawn = pawnComponent;
                }
            }
            Health healthComponent = tempPawn.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.maxHealth = 10;
            }

        }
        
    }
}
