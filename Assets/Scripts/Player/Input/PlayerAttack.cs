using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputPlayer inputActions;

    [SerializeField] private GameObject attackBox;
    [SerializeField] private PlayerMovement playerMovement;

    private Coroutine attackCoroutine;
    private bool isAttacking = false;
    private GameObject currentHitbox;
    private Vector2 offset = Vector2.zero;

    public float offsetValue;



    private void Awake()
    {
        inputActions = new InputPlayer();
        inputActions.Player.Attack.Enable();
        inputActions.Player.Attack.performed += AttackPerformed;
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        CheckRotation(playerMovement.direction);
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
        Vector3 spawnPosition = transform.position + new Vector3(offset.x, offset.y, 0);

        currentHitbox = Instantiate(attackBox, spawnPosition, Quaternion.identity, transform);

        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
        Destroy(currentHitbox);
    }


    public void CheckRotation(direction dir)
    {
        switch (dir)
        {
            case direction.up:
                offset = new Vector2(0, offsetValue);
                break;
            case direction.down:
                offset = new Vector2(0, -offsetValue);
                break;
            case direction.left:
                offset = new Vector2(-offsetValue, 0);
                break;
            case direction.right:
                offset = new Vector2(offsetValue, 0);
                break;
            default:
                break;
        }
    }

}
