using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AttackCheckMethod
{
    TimerBased,
    DetectionBased
}

public class IdleState : IEnemyState
{
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private float idleTimer = 0f;
    private IdleConfig config;

    public IdleState(EnemyController controller, EnemyType type, IdleConfig config)
    {
        enemyController = controller;
        enemyType = type;
        this.config = config;
    }

    public virtual void EnterState()
    {
        // Enter idle state behavior
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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(enemyController.gameObject.transform.position, config.detectionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<PlayerMovement>())
                {
                    Attack(collider.gameObject);
                }
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

    }
    public virtual void Attack(GameObject target)
    {

    }

    public virtual void ExitState()
    {
        // Exit idle state behavior
    }
}