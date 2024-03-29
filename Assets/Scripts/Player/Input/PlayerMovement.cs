using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private InputPlayer inputPlayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Image dashImage;

    [SerializeField] private float fillDuration = 2f;
    [SerializeField] private float speed = 10;
    [SerializeField] private float dashSpeed = 20;
    [SerializeField] private float runThreshold = 0.5f;

    private bool canDash = true;
    void Awake()
    {
        inputPlayer = new InputPlayer();
        inputPlayer.Player.Movement.Enable();
        inputPlayer.Player.Dash.Enable();
        inputPlayer.Player.Dash.performed += Dash_performed;
    }

    private void Dash_performed(InputAction.CallbackContext obj)
    {
        Vector2 input = GetInputValue();
        if (canDash && input != Vector2.zero)
        {
            dashImage.fillAmount = 0;
            StartCoroutine(Dash(GetInputValue()));
        }
    }

    public Vector2 GetInputValue()
    {
        Vector2 input = inputPlayer.Player.Movement.ReadValue<Vector2>();
        return input;
    }


    private void HandleMovement()
    {
        Vector2 input = GetInputValue();
        bool isrunning = (input.magnitude > runThreshold) ? true : false;

        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;

        if (isrunning) transform.position += dir * speed * Time.deltaTime;

        else transform.position += dir * speed * 0.33f * Time.deltaTime;
    }

    private IEnumerator Dash(Vector3 dirr)
    {
        canDash = false;
        Vector2 force = new Vector2(dirr.x, dirr.y).normalized * dashSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.2f);
        rb.velocity = Vector2.zero;
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            dashImage.fillAmount = Mathf.Lerp(0f, 1f, elapsedTime / fillDuration);
        }
        dashImage.fillAmount = 1f;
        canDash = true;
    }


    private void Update()
    {
        HandleMovement();
    }
}
