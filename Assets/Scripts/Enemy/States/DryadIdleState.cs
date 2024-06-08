using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadIdleState : IdleState
{

    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private AttackState spikeComponent;
    public DryadIdleState(EnemyController controller, EnemyType type, IdleConfig config, PlayerDetector playerDetector, AttackState attackBehavior) : base(controller, type, config, playerDetector)
    {
        enemyController = controller;
        enemyType = type;
        spikeComponent = attackBehavior;
    }


    public override void Attack(GameObject target)
    {
        if (spikeComponent != null)
        {
            enemyController.ChangeState(spikeComponent);
            spikeComponent.idle = this;
            spikeComponent.enemyController = enemyController;
            spikeComponent.playerDetector = detection;
            spikeComponent.target = target;
        }
    }

}
