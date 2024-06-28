using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingIdleState : IdleState
{
    public FlockingIdleState(EnemyController controller, EnemyType type, IdleConfig config, PlayerDetector playerDetector,AttackState attackState) : base(controller, type, config, playerDetector,attackState)
    {
    }

    public override void Attack()
    {
        base.Attack();
    }
}
