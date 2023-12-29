using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupLogic : MonoBehaviour, Ipickup
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private float amount;
    public void Pickup()
    {
        Debug.Log("You picked something up");
        _healthSystem?.GiveHealth(amount);
        GameObject.Destroy(gameObject);
        
    }

}
