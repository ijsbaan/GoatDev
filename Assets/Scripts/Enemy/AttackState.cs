using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackState : IEnemyState
{
    private readonly EnemyStateMachine enemyController;
    private readonly AttackType attackType;
    EnemyShoot shoot;

    public AttackState(EnemyStateMachine controller, AttackType type)
    {
        enemyController = controller;
        attackType = type;
    }

    public void EnterState()
    {
        // Enter attack state behavior
        if (attackType == AttackType.ranged)
        {
            shoot = enemyController.attack.GetComponent<EnemyShoot>();
            shoot.enabled = true;
        }
    }

    public void UpdateState()
    {
        // Attack state update behavior

        //shoot.ShootAtPosition(new Vector3(0,0,0));
    }

    public void ExitState()
    {
        // Exit attack state behavior
    }
}
