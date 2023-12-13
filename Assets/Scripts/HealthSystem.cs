using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    
    public void RemoveHealth(float removeAmount)
    {
        health -= removeAmount;
    }
    
    public void Death()
    {
        GameObject.Destroy(gameObject);
    }

    public void SetMaxHealth()
    {
        health = maxHealth;
    }

    public void GiveHealth(float amount)
    {
        health += amount;
    }
}
