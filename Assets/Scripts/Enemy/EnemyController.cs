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
    [SerializeField] private IEnemyState currentState;
    [SerializeField] EnemyType enemyType;
    [SerializeField] public GameObject enemyObject;
    [SerializeField] IdleConfig idleConfig;
    [SerializeField] AttackState attackBehavior;
    

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
                ChangeState(new IdleState(this, enemyType, idleConfig));
                break;
            case EnemyType.flocking:
                ChangeState(new FlockingIdleState(this, enemyType, idleConfig));
                break;
            case EnemyType.tower:
                ChangeState(new TowerIdleState(this, enemyType, idleConfig, attackBehavior));
                break;
            case EnemyType.dryad:
                EnemySpike spikeComponent = GetComponent<EnemySpike>();
                ChangeState(new DryadIdleState(this, enemyType, idleConfig, spikeComponent));
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
