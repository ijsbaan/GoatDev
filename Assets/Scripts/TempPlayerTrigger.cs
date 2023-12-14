using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerTrigger : MonoBehaviour
{
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
            if (Input.GetKey(KeyCode.E)) { interactable.Interact(); }
        }
    }
}
