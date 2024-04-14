using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private float idleTimer = 0f;
    private float idleDuration = 5f;

    public IdleState(EnemyController controller,EnemyType type)
    {
        enemyController = controller;
        enemyType = type;
    }

    public void EnterState()
    {
        // Enter idle state behavior
    }

    public virtual void UpdateState()
    {
        // Implement idle behavior here (e.g., patrol, look around, etc.)
        idleTimer += Time.deltaTime;

        // Example: If idle duration is reached, transition to another state (e.g., AttackState)
        if (idleTimer >= idleDuration)
        {
            Attack();
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

    public void ExitState()
    {
        // Exit idle state behavior
    }
}