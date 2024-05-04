using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject camera;
    private PlayerMovement playermovement;
    

    private bool isInteracting;
    private bool canInteract;
    private bool cameraOn;  
 
    public void Interact()
    { 

        Debug.Log("interact");

        isInteracting = !isInteracting;
        
        if(this.gameObject.tag == "Chest")
        {
            if (isInteracting)
            {
                camera.SetActive(true);
            }

            else 
                camera.SetActive(false);
            
        }

        if(this.gameObject.tag ==" NPC")
        {
            
        }
    }
}
