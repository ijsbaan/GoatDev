using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private readonly EnemyStateMachine enemyController;
    private readonly EnemyType enemyType;
    private float idleTimer = 0f;
    private float idleDuration = 3f;

    public IdleState(EnemyStateMachine controller,EnemyType type)
    {
        enemyController = controller;
        enemyType = type;
    }

    public void EnterState()
    {
        // Enter idle state behavior
    }

    public void UpdateState()
    {
        // Implement idle behavior here (e.g., patrol, look around, etc.)
        idleTimer += Time.deltaTime;

        // Example: If idle duration is reached, transition to another state (e.g., AttackState)
        if (idleTimer >= idleDuration)
        {
            if (enemyType == EnemyType.tower)
            {
                enemyController.ChangeState(new AttackState(enemyController,AttackType.ranged));
            }
        }


    }

    public void ExitState()
    {
        // Exit idle state behavior
    }
}