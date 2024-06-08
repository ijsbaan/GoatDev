using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractNPC : MonoBehaviour, Iinteractable
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject canvas;
    [SerializeField] ReadFile DialogueReader;
    [SerializeField] Animator animator;
    
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
            if(animator != null)
            {
                animator.SetBool("Talking",true);
            }
            DialogueReader.GenerateDialogue(DialogueReader.FirstDialogueId);
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("Talking", false);
            }
            canvas.SetActive(false);
        }
    }
}
