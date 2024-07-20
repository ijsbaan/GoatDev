using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputPlayer inputActions; // Reference to the input actions

    [SerializeField] private GameObject attackBox; // Prefab for the attack hitbox
    [SerializeField] private PlayerMovement playerMovement; // Reference to the player movement script

    private Coroutine attackCoroutine; // Reference to the current attack coroutine
    private bool isAttacking = false; // Flag to check if the player is currently attacking
    private GameObject currentHitbox; // Reference to the current attack hitbox
    private Vector2 offset = Vector2.zero; // Offset for the attack hitbox position

    public float offsetValue; // Value to set the offset distance for the attack hitbox

    [SerializeField] private float AttackDamage; // Damage value for the attack

    /// <summary>
    /// Initialize input actions and set up attack input
    /// </summary>
    private void Awake()
    {
        inputActions = playerMovement.inputPlayer; // Initialize input actions
        inputActions.Player.Attack.Enable(); // Enable attack input
        inputActions.Player.Attack.performed += AttackPerformed; // Register the attack performed event
    }

    /// <summary>
    /// Callback when the attack input is performed
    /// </summary>
    /// <param name="obj"></param>
    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        CheckRotation(playerMovement.direction); // Check the player's direction and set the offset

        if (isAttacking)
        {
            StopCoroutine(attackCoroutine); // Stop the current attack coroutine if attacking
            Destroy(currentHitbox); // Destroy the current hitbox
        }
        attackCoroutine = StartCoroutine(Attack()); // Start a new attack coroutine
    }

    /// <summary>
    /// Coroutine to handle the attack process
    /// </summary>
    /// <returns></returns>
    public IEnumerator Attack()
    {
        Vector3 spawnPosition = transform.position + new Vector3(offset.x, offset.y, 0); // Calculate spawn position with offset

        currentHitbox = Instantiate(attackBox, spawnPosition, transform.rotation, transform); // Instantiate the attack hitbox
        currentHitbox.GetComponent<DamageColliderByTag>().damage = AttackDamage; // Set the damage value for the hitbox

        playerMovement.canMove = false; // Deactivated playerMovement

        isAttacking = true; // Set attacking flag to true
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds

        isAttacking = false; // Set attacking flag to false
        Destroy(currentHitbox); // Destroy the attack hitbox
    }

    /// <summary>
    /// Check the player's direction and set the offset for the attack hitbox
    /// </summary>
    /// <param name="dir"></param>
    public void CheckRotation(direction dir)
    {
        switch (dir)
        {
            case direction.up:
                offset = new Vector2(0, offsetValue); // Set offset for upward direction
                break;
            case direction.down:
                offset = new Vector2(0, -offsetValue); // Set offset for downward direction
                break;
            case direction.left:
                offset = new Vector2(-offsetValue, 0); // Set offset for left direction
                break;
            case direction.right:
                offset = new Vector2(offsetValue, 0); // Set offset for right direction
                break;
            default:
                break;
        }
    }
}
