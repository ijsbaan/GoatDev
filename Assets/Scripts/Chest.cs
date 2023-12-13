using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Iinteractable
{ 

    public void Interact()
    {
        Debug.Log("interact");
        GameObject.Destroy(gameObject);
    }
}
