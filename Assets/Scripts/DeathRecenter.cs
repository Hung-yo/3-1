using UnityEngine;

public class DeathRecenter : Death
{
    private Health health;
    public AudioSource deathClip;
    public Vector3 spawnPoint;
    public Pawn pawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Die()
    {
        if (GameManager.lives <= 0)
        {
            if (deathClip != null)
            {
                AudioSource.PlayClipAtPoint(deathClip.clip, transform.position);
            }
            Destroy(gameObject);
            return;
        } else
        {
            GameManager.lives -= 1;
            Debug.Log("Pawn Died, teleported to origin");
            // Sets pawn rotation and speed back to 0 when respawning
            pawn.rigidBody.linearVelocity = Vector3.zero;
            pawn.rigidBody.angularVelocity = Vector3.zero;
            pawn.transform.rotation = Quaternion.identity;
            transform.position = spawnPoint;
            health.currentHealth = health.maxHealth;
        }
    }
}
