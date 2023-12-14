using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject camera;
    private bool isInteracting;
    public void Interact()
    { 

        Debug.Log("interact");

        isInteracting = !isInteracting;
        //GameObject.Destroy(gameObject);
        if (isInteracting)  camera.SetActive(true);
        else camera.SetActive(false);
    }

}
