using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerTrigger : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Iinteractable interact;
   [SerializeField] private bool canInteract = false;

    private void Start()
    {
        interact = gameObject.GetComponent<Iinteractable>();
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Interact.performed += InteractPerformed;
    }

    private void InteractPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        canInteract = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ipickup ipickup = collision.gameObject.GetComponent<Ipickup>();
        if (ipickup != null)
        {
            ipickup.Pickup();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Iinteractable interactable = collision.gameObject.GetComponent<Iinteractable>();
        if (interactable != null)
        {
            inputPlayer.Player.Interact.Enable();
            if (canInteract) { interactable.Interact(); canInteract = false; }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Iinteractable interactable = collision.gameObject.GetComponent<Iinteractable>();
        if (interactable != null)
        {
            inputPlayer.Player.Interact.Disable();
        }
    }
}
