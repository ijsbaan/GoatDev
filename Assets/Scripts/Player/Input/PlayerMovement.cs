using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private InputPlayer inputPlayer;
    [SerializeField] private int speed = 10;
    void Awake()
    {
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Movement.Enable();
    }

    public Vector2 GetInputValue()
    {
        Vector2 input = inputPlayer.Player.Movement.ReadValue<Vector2>();
        
        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;
        transform.position += dir * speed * Time.deltaTime;
            
        return input;
    }

    private void FixedUpdate()
    {
        GetInputValue();
    }
}
