using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrigger : MonoBehaviour
{
    private InputPlayer inputPlayer;
    private Iinteractable interact;
    [SerializeField] private bool canInteract = false;

    public float radius = 0.5f;

    private void Start()
    {
        interact = gameObject.GetComponent<Iinteractable>();
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Interact.Enable();
        inputPlayer.Player.Interact.performed += InteractPerformed;
    }

    private void InteractPerformed(InputAction.CallbackContext obj)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<InteractObject>() != null)
            {
                InteractObject interactObject = collider.GetComponent<InteractObject>();
                interactObject.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }

}
