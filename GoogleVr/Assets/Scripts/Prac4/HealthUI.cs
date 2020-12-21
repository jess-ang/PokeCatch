using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    protected float maxHealth, currentHealth;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitializeHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;
    }

    public void SetHealth(float newHealth)
    {
        currentHealth = newHealth;
        float healthRatio = currentHealth / maxHealth;
        image.fillAmount = healthRatio;
    }
}
