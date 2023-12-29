using UnityEngine;



public enum AttackType
{
    melee,
    ranged
}

public enum EnemyType
{
    basic,
    chasing,
    tower
}

public class EnemyStateMachine : MonoBehaviour
{
    private IEnemyState currentState;
    [SerializeField] internal Attack attack;
    [SerializeField] EnemyType enemyType;

    // Set the initial state (e.g., in Start() method)
    private void Start()
    {
        ChangeState(new IdleState(this,enemyType));
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
}
