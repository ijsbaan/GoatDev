using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColliderByTag : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] private bool DestroyAfterHit;
    [SerializeField] public string Tag;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            var health = other.gameObject.GetComponent<HealthSystem>();
            health.RemoveHealth(damage, this.gameObject.transform);
            if (DestroyAfterHit)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
