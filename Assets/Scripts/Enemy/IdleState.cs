using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private readonly EnemyController enemyController;
    private float idleTimer = 0f;
    private float idleDuration = 3f;

    public IdleState(EnemyController controller)
    {
        enemyController = controller;
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
            enemyController.ChangeState(new AttackState(enemyController));
        }
    }

    public void ExitState()
    {
        // Exit idle state behavior
    }
}