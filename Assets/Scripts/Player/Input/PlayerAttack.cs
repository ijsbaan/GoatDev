using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputPlayer inputActions;
    [SerializeField] private GameObject attackBox;
    private Coroutine attackCoroutine;
    private bool isAttacking = false;
    private GameObject currentHitbox;



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
        // Start a new attack
        if (isAttacking)
        {
            StopCoroutine(attackCoroutine);
            Destroy(currentHitbox);
        }
        attackCoroutine = StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        Vector3 spawnPosition = transform.position + MovementDirection();

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, MovementDirection());

        currentHitbox = Instantiate(attackBox, spawnPosition, rotation);

        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
        Destroy(currentHitbox);
    }
}
