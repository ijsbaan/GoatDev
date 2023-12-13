using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float damage;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
           var health = other.gameObject.GetComponent<HealthSystem>();
           health.RemoveHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
