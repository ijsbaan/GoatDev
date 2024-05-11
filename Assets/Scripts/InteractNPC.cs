using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : MonoBehaviour, Iinteractable
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject canvas;
    
    public void Interact()
    {
        playerMovement.canMove = !playerMovement.canMove;

        Dialogue();
    }

    public void Dialogue()
    { 
        if(!playerMovement.canMove)
        {
            canvas.SetActive(true); 
        }

        else
        {
            canvas.SetActive(false);
        }
    }
}
