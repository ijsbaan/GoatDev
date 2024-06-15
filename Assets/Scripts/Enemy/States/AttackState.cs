using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
public class AttackState : MonoBehaviour, IEnemyState
{
    public EnemyController enemyController;
    public GameObject target;
    public float detectionRadius;
    public PlayerDetector playerDetector;
    public IdleState idle;

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {
        if (!playerDetector.PlayerDetected)
        {
            enemyController.ChangeState(idle);
        }
    }

    public virtual void ExitState()
    {
        // Exit attack state behavior
    }
}
