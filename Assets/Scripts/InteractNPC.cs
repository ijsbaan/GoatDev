using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractNPC : MonoBehaviour, Iinteractable
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject canvas;
    [SerializeField] ReadFile DialogueReader;
    
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
            DialogueReader.GenerateDialogue(DialogueReader.FirstDialogueId);
        }

        else
        {
            canvas.SetActive(false);
        }
    }
}
