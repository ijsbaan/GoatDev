using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool PlayerDetected;
    public GameObject Player;
    private CircleCollider2D Collider;
    public float DetectionRadius;

    public void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
    }
    public void Update()
    {
        Collider.radius = DetectionRadius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            PlayerDetected = true;
            Player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            PlayerDetected = false;
            Player = null;
        }
    }
}
