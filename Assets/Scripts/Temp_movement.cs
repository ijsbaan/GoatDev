using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ipickup ipickup = collision.gameObject.GetComponent<Ipickup>();
        if(ipickup != null )
        {
            ipickup.Pickup();
        }
    }
}