using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupLogic : MonoBehaviour, Ipickup
{
    public void Pickup()
    {
        Debug.Log("You picked something up");
        GameObject.Destroy(gameObject);
    }

}
