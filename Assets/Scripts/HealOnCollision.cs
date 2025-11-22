using UnityEngine;

public class HealOnCollision : MonoBehaviour
{
    public int healAmount = 1;
    public bool hasCollided = false;
    public bool destroyOnCollision = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided && destroyOnCollision)
        {
            OnDestroy();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        Health otherHealth = other.gameObject.GetComponent<Health>();
        Pawn isPawn = other.gameObject.GetComponent<Pawn>();
        if (otherHealth != null)
        {
            if (isPawn)
            {
                otherHealth.Heal(healAmount);
            }
            hasCollided = true;
        }
        else
        {
            Debug.Log(other.gameObject.name + " has no health component.");
        }
    }
    
    void OnDestroy()
    {
        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }
}
