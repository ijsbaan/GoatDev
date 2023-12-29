using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackState : IEnemyState
{
    private readonly EnemyController enemyController;

    public AttackState(EnemyController controller)
    {
        enemyController = controller;
    }

    public void EnterState()
    {
        // Enter attack state behavior
    }

    public void UpdateState()
    {
        // Attack state update behavior
    }

    public void ExitState()
    {
        // Exit attack state behavior
    }
}
