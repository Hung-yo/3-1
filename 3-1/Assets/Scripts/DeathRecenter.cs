using UnityEngine;

public class DeathRecenter : Death
{
    private Health health;
    public AudioSource deathClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
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
            transform.position = Vector3.zero;
            health.currentHealth = health.maxHealth;
        }
    }
}
