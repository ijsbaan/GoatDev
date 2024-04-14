using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadIdleState : IdleState
{

    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private EnemySpike spikeComponent;
    public DryadIdleState(EnemyController controller, EnemyType type, EnemySpike attackBehavior) : base(controller, type)
    {
        enemyController = controller;
        enemyType = type;
        spikeComponent = attackBehavior;
    }


    public override void Attack()
    {
        if (spikeComponent != null)
        {
            enemyController.ChangeState(spikeComponent);
        }
    }

}
