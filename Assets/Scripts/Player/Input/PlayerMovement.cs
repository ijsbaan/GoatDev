using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private InputPlayer inputPlayer;

    [SerializeField] private float speed = 10;
    [SerializeField] private float runThreshold = 0.5f;
    void Awake()
    {
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Movement.Enable();
    }

    public Vector2 GetInputValue()
    {
        Vector2 input = inputPlayer.Player.Movement.ReadValue<Vector2>();

        bool isrunning = (input.magnitude > runThreshold) ? true : false;

        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;

        if (isrunning) transform.position += dir * speed * Time.deltaTime;
         
        else transform.position += dir * speed * 0.5f * Time.deltaTime;
            
        return input;
    }


    private void Update()
    {
        GetInputValue();
    }
}
