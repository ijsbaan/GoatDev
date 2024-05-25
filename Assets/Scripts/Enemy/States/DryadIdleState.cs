using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadIdleState : IdleState
{

    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private EnemySpike spikeComponent;
    public DryadIdleState(EnemyController controller, EnemyType type, IdleConfig config, EnemySpike attackBehavior) : base(controller, type, config)
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
            spikeComponent.controller = enemyController;
            spikeComponent.player = target;
        }
    }

}
