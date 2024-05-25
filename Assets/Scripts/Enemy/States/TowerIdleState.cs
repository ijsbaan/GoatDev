using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleState : IdleState
{
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private AttackState attackState;
    private IdleConfig config;
    public TowerIdleState(EnemyController controller, EnemyType type, IdleConfig config, AttackState attackBehavior) : base(controller, type, config)
    {
        enemyController = controller;
        enemyType = type;
        this.config = config;
        this.attackState = attackBehavior;
    }

    public override void Attack(GameObject target)
    {
        if (attackState != null)
        {
            attackState.target = target;
            attackState.detectionRadius = config.detectionRadius;
            attackState.idle = this;
            attackState.enemyController = enemyController;
            enemyController.ChangeState(attackState);
        }
    }
}
