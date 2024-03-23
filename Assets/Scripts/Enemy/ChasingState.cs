using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : IEnemyState
{
    
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private readonly Transform playerTransform;
    private FlockingBehavior flocking;
    private readonly float chaseSpeed;
    private float detectionRange; // The distance at which the enemy detects the player
    private float fieldOfViewAngle; // The angle of the enemy's field of view
    private bool playerDetected;

    public ChasingState(EnemyController controller, EnemyType type, Transform player, float fovAngle,float detectionrange,float speed,FlockingBehavior flockingBehavior)
    {
        enemyController = controller;
        enemyType = type;
        playerTransform = player;
        this.chaseSpeed = speed;
        this.fieldOfViewAngle = fovAngle;
        this.detectionRange = detectionrange;
        this.flocking = flockingBehavior;
    }

    public void EnterState()
    {
        playerDetected = false;
    }

    public void UpdateState()
    {
        if (!playerDetected && playerTransform != null)
        {
            Vector2 directionToPlayer = playerTransform.position - enemyController.transform.position;
            float angleToPlayer = Vector2.Angle(enemyController.transform.right, directionToPlayer);

            // Check if player is within FOV angle and detection range
            if (angleToPlayer <= fieldOfViewAngle * 0.5f)
            {
                RaycastHit2D hit = Physics2D.Raycast(enemyController.transform.position, directionToPlayer, detectionRange);
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    playerDetected = true;
                }
            }
        }

        if (playerDetected)
        {
            // Chase state update behavior
            if (playerTransform != null)
            {
                Vector3 direction = (playerTransform.position - enemyController.transform.position).normalized;
                enemyController.parent.transform.position += direction * chaseSpeed * Time.deltaTime;
            }
        }
    }

    public void ExitState()
    {
        playerDetected = false;
        detectionRange = 0;
        fieldOfViewAngle = 0;
    }
}

