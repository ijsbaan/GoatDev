using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
public class AttackState : MonoBehaviour, IEnemyState
{
    public EnemyController enemyController;
    public GameObject target;
    public float detectionRadius;
    bool playerNear;
    public IdleState idle;

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
        if (playerDetected && enemyController.currentState != this)
        {
            enemyController.ChangeState(this);
        }
        // If the player is not near, change the state to idle
        if (!playerNear && enemyController.currentState != idle)
        {
            enemyController.ChangeState(idle);
        }
    }

    public virtual void ExitState()
    {
        // Exit attack state behavior
    }
}
