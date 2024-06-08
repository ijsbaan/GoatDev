using UnityEngine;



public enum AttackType
{
    melee,
    ranged
}

public enum EnemyType
{
    basic,
    flocking,
    tower,
    dryad
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] public IEnemyState currentState;
    [SerializeField] EnemyType enemyType;
    [SerializeField] public GameObject enemyObject;
    [SerializeField] IdleConfig idleConfig;
    [SerializeField] AttackState attackBehavior;
    [SerializeField] PlayerDetector playerDetector;


    // Set the initial state (e.g., in Start() method)
    private void Start()
    {
        SetInitialState();
    }

    private void SetInitialState()
    {
        // Depending on enemyType, set the initial state
        switch (enemyType)
        {
            case EnemyType.basic:
                ChangeState(new IdleState(this, enemyType, idleConfig, playerDetector));
                break;
            case EnemyType.flocking:
                ChangeState(new FlockingIdleState(this, enemyType, idleConfig, playerDetector));
                break;
            case EnemyType.tower:
                ChangeState(new TowerIdleState(this, enemyType, idleConfig, playerDetector, attackBehavior));
                break;
            case EnemyType.dryad:
                ChangeState(new DryadIdleState(this, enemyType, idleConfig, playerDetector, attackBehavior));
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
        Debug.Log(currentState.ToString());
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;
        currentState.EnterState();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, idleConfig.detectionRadius);
    }
}
