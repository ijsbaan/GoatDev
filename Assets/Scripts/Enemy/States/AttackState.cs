using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackState : IEnemyState
{
    private readonly EnemyController enemyController;
    private readonly AttackType attackType;

    public AttackState(EnemyController controller, AttackType type)
    {
        enemyController = controller;
        attackType = type;
    }

    public void EnterState()
    {

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
