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

    [SerializeField] private bool cantKnockBack;


    private Transform damageCollider;
    private Rigidbody2D rb;

    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    private void Awake()
    {
        healthAmount = maxHealth;
        SetHealth(GetHealthNormalized());
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (healthAmount <= 0)
        {
            Death();
        }
    }

    public void RemoveHealth(float removeAmount, Transform damage)
    {
        damageCollider = damage;
        healthAmount -= removeAmount;
        SetHealth(GetHealthNormalized());

        if(!cantKnockBack)
        {
            KnockBack(damageCollider);
        }
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
    private void KnockBack(Transform objectTransform)
    {
        Vector2 distance = this.transform.position - objectTransform.position;

        StartCoroutine(CallKnockBack(distance, new Vector2(1, 1)));
    }

    private IEnumerator CallKnockBack(Vector2 hitDirection, Vector2 constantForceDirection)
    {
        float elapsedTime = 0;

        Vector2 hitForce;
        Vector2 constantForce;
        Vector2 combinedForce;

        hitForce = hitDirection * hitDirectionForce;
        constantForce = constantForceDirection * constForce;

        while (elapsedTime < knockbackTime)
        {
            elapsedTime += Time.deltaTime;

            combinedForce = hitForce ;

            rb.velocity = combinedForce;

            yield return new WaitForFixedUpdate();
        }

        rb.velocity = Vector2.zero;
    }

}
