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
        if (enemyType == EnemyType.flocking)
        {
            ChangeState(new FlockingIdleState(this, enemyType, idleConfig, playerDetector, attackBehavior));
        }
        else
        {
            ChangeState(new IdleState(this, enemyType, idleConfig, playerDetector, attackBehavior));
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
