using UnityEngine;

public class HealthBar : Health
{
    public Health health;
    public GameObject healthImage;
    private float initialScaleX;
    private Vector3 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialScaleX = healthImage.transform.localScale.x;
        initialPosition = healthImage.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar(health.currentHealth, health.maxHealth);
    }

    void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float healthPercent = Mathf.Clamp01(currentHealth / maxHealth);

        if (healthImage != null)
        {
            Vector3 scale = healthImage.transform.localScale;
            scale.x = initialScaleX * healthPercent;
            healthImage.transform.localScale = scale;

            Vector3 pos = initialPosition;
            pos.x = initialPosition.x - (initialScaleX * (1 - healthPercent) * 0.5f);
            healthImage.transform.localPosition = pos;
        }
    }
}
