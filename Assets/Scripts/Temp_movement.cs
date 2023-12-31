using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    public Rigidbody2D rb;
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 input = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }


        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        Vector3 dashdir = new Vector3(input.x, input.y, 0).normalized;
        if (Input.GetKeyDown(KeyCode.Space)) { StartCoroutine(Dahs(dashdir)); }
        Dahs(dashdir);
    }

    private IEnumerator Dahs(Vector3 dirr)
    {

        rb.AddForce(dirr * 20, ForceMode2D.Impulse);
        Debug.Log("Dash");
        yield return new WaitForSeconds(.2f);
        rb.velocity = Vector2.zero;
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
            if (Input.GetKey(KeyCode.E)) { interactable.Interact(); }
        }
    }
}