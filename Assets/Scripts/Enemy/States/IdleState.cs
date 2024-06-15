using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class IdleState : IEnemyState
{
    private AttackState attackState;
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private float idleTimer = 0f;
    private IdleConfig config;
    protected PlayerDetector detection;
    bool inAttackingState;
    public IdleState(EnemyController controller, EnemyType type, IdleConfig config, PlayerDetector playerDetector, AttackState attackState)
    {
        enemyController = controller;
        enemyType = type;
        this.config = config;
        detection = playerDetector;
        this.attackState = attackState;
    }

    public virtual void EnterState()
    {
        // Enter idle state behavior
        detection.DetectionRadius = config.detectionRadius;
    }

    public virtual void UpdateState()
    {
        if (config.attackCheckMethod == AttackCheckMethod.TimerBased)
        {
            // Implement idle behavior here (e.g., patrol, look around, etc.)
            idleTimer += Time.deltaTime;

            // Example: If idle duration is reached, transition to another state (e.g., AttackState)
            if (idleTimer >= config.idleDuration)
            {
                Attack();
            }
        }
        if (config.attackCheckMethod == AttackCheckMethod.DetectionBased)
        {
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(enemyController.gameObject.transform.position, config.detectionRadius);
            //foreach (Collider2D collider in colliders)
            //{
            //    if (collider.GetComponent<PlayerMovement>())
            //    {
            //        Attack(collider.gameObject);
            //    }
            //}
            if (detection.PlayerDetected && !inAttackingState)
            {
                if (detection.Player != null)
                    Attack(detection.Player);
                inAttackingState = true;
            }
            if (!detection.PlayerDetected)
            {
                inAttackingState = false;
                enemyController.ChangeState(this);
            }
        }


    }

    public virtual void WalkAround()
    {
        System.Random rand = new System.Random();
        Vector3 position = new Vector3(rand.Next(0, 10), rand.Next(0, 10), 0);
        enemyController.enemyObject.transform.position = Vector3.Lerp(enemyController.gameObject.transform.position, position, 0.5f);
    }

    public virtual void Attack()
    {
        if (attackState != null)
        {
            attackState.idle = this;
            attackState.enemyController = enemyController;
            enemyController.ChangeState(attackState);
        }
    }
    public virtual void Attack(GameObject target)
    {
        if (attackState != null)
        {
            attackState.target = target;
            attackState.playerDetector = detection;
            attackState.idle = this;
            attackState.enemyController = enemyController;
            enemyController.ChangeState(attackState);
        }

    }

    public virtual void ExitState()
    {
        // Exit idle state behavior
    }
}