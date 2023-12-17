using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerTrigger : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Iinteractable interact;

    private void Start()
    {
        interact = gameObject.GetComponent<Iinteractable>();
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Interact.Enable();
        inputPlayer.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //interact.Interact();
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
            if (inputPlayer.Player.Interact.triggered) { interactable.Interact(); }
        }
    }
}
