using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    public float blinkDuration = 0.1f;
    public float maxHealth = 10f;
    public float currentHealth;
    public bool isInstaKill = false;
    public bool blinkOnDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        renderer = GetComponentInChildren<Renderer>();
        originalColor = renderer.material.color;
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
        if (blinkOnDamage)
        {
            StartCoroutine(BlinkRed());
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private IEnumerator BlinkRed()
    {
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(blinkDuration);
        renderer.material.color = originalColor;
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
