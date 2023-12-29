using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private float healthAmount;
    private float maxHealth;

    private void Awake()
    {
        maxHealth = healthAmount;
        SetHealth(GetHealthNormalized());
    }

    public void RemoveHealth(float removeAmount)
    {
        healthAmount -= removeAmount;
        SetHealth(GetHealthNormalized());
    }


    public void Death()
    {
        GameObject.Destroy(gameObject);
    }

    public void SetMaxHealth()
    {
        healthAmount = maxHealth;
        SetHealth(GetHealthNormalized());
    }

    public void GiveHealth(float amount)
    {
        healthAmount += amount;
        SetHealth(GetHealthNormalized());
    }

    public float GetHealthNormalized()
    {
        return healthAmount / maxHealth;
    }
    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    }
}
