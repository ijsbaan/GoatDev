using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private float healthAmount;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject affectedObject;

    private void Awake()
    {
        healthAmount = maxHealth;
        SetHealth(GetHealthNormalized());
    }

    private void FixedUpdate()
    {
        if (healthAmount <= 0)
        {
            Death();
        }
    }

    public void RemoveHealth(float removeAmount)
    {
        healthAmount -= removeAmount;
        SetHealth(GetHealthNormalized());
    }

    public void Death()
    {

        if (GetComponent<FlockAgent>() != null)
        {
            FlockAgent flock = GetComponent<FlockAgent>();
            flock.Death();
        }
        GameObject.Destroy(affectedObject);
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
