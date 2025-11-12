using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public bool isInstaKill = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstaKill && currentHealth > 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    /*
    public void TakeDamage(DamageData damageData)
    {
        AudioSource.PlayOneShot(damageInfo.damageSoundEffect);
        Debug.Log("You have been damaged by " + damageInfo.damageDealer.gameObject.name);
        TakeDamage(damageInfo.damage)
    }*/

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }
}
