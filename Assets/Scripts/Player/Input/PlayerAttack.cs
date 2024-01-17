using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputPlayer inputActions;
    [SerializeField] private GameObject attackBox;
    private Coroutine attackCoroutine;
    private bool isAttacking = false;

    private void Awake()
    {
        inputActions = new InputPlayer();
        inputActions.Player.Attack.Enable();
        inputActions.Player.Attack.performed += AttackPerformed;
    }

    private Vector3 MovementDirection()
    {
        Vector2 input = inputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;
        return dir;
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        // If an attack is already in progress, do nothing
        if (isAttacking)
        {
            return;
        }

        // Start a new attack
        attackCoroutine = StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        isAttacking = true;

        var hitbox = Instantiate(attackBox, gameObject.transform.position + MovementDirection(), Quaternion.identity);

        // Initiate recursive countdown for hitbox lifetime
        yield return StartCoroutine(RecursiveCountdownCoroutine(2, hitbox));

        Destroy(hitbox);
        isAttacking = false;
    }

    private IEnumerator RecursiveCountdownCoroutine(float timeRemaining, GameObject hitbox)
    {
        // Base case
        if (timeRemaining <= 0)
        {
            yield break;
        }

        // Check if cancellation condition is met
        if (CancelCondition())
        {
            Debug.Log("Attack cancelled.");
            yield break;
        }

        Debug.Log($"Time remaining: {timeRemaining}");

        // Wait for a short duration
        yield return new WaitForSeconds(0.1f);

        // Recursive call
        yield return StartCoroutine(RecursiveCountdownCoroutine(timeRemaining - 0.1f, hitbox));
    }

    private bool CancelCondition()
    {
        // Check if the attack input is performed again
        return inputActions.Player.Attack.triggered;
    }
}
