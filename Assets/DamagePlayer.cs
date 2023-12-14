using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var health = other.gameObject.GetComponent<HealthSystem>();
            health.RemoveHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
