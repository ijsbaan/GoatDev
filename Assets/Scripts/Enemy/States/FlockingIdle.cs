using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingIdleState : IdleState
{

    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;

    public override void EnterState()
    {
        base.EnterState();
        enemyController.GetComponent<Flock>().enabled = false;
    }
    public FlockingIdleState(EnemyController controller, EnemyType type, IdleConfig config, PlayerDetector playerDetector) : base(controller, type, config, playerDetector)
    {
        enemyController = controller;
        enemyType = type;
    }

    public override void Attack()
    {
        enemyController.GetComponent<Flock>().enabled = true;
    }
}
