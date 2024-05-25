using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
public class AttackState : MonoBehaviour, IEnemyState
{
    private readonly EnemyController enemyController;
    private readonly AttackType attackType;
    public GameObject target;
    public float detectionRadius;
    bool playerNear;
    public IdleState idle;

    public AttackState(EnemyController controller, AttackType type)
    {
        enemyController = controller;
        attackType = type;
    }

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {
        // Check if the player is within the detection radius
        bool playerDetected = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider == target.GetComponent<Collider2D>())
            {
                playerDetected = true;
                break;
            }
        }
        playerNear = playerDetected;

        // If the player is not near, change the state to idle
        if (!playerNear)
        {
            enemyController.ChangeState(idle);
        }
    }

    public virtual void ExitState()
    {
        // Exit attack state behavior
    }
}
