using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputPlayer inputActions;
    [SerializeField] private GameObject attackBox;
    


    private void Awake()
    {
        inputActions = new InputPlayer();
        inputActions.Player.Attack.Enable();
        inputActions.Player.Attack.performed +=Attack_performed;
    }
    private Vector3 movementDirection()
    {
        Vector2 input = inputActions.Player.Movement.ReadValue<Vector2>();

        Vector3 dir = new Vector3(input.x, input.y, 0).normalized;
        return dir;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {

        StartCoroutine("Attack");
    }

    public IEnumerator Attack()
    {
        var hitbox = Instantiate(attackBox, gameObject.transform.position + movementDirection(), Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(hitbox);
    }


}
