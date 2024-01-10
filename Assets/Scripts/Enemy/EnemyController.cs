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

public class EnemyController : MonoBehaviour
{
    private IEnemyState currentState;
    [SerializeField] EnemyType enemyType;
    internal GameObject enemyObject;

    // Add a reference to the FlockingBehavior
    private FlockingBehavior flockingBehavior;

    // Set the initial state (e.g., in Start() method)
    private void Start()
    {
        SetInitialState();
        enemyObject = this.gameObject;

        // Initialize the flocking behavior
        flockingBehavior = GetComponent<FlockingBehavior>();
        if (flockingBehavior == null)
        {
            flockingBehavior = gameObject.AddComponent<FlockingBehavior>();
        }
    }

    private void SetInitialState()
    {
        // Depending on enemyType, set the initial state
        switch (enemyType)
        {
            case EnemyType.basic:
                ChangeState(new IdleState(this, enemyType));
                break;
            case EnemyType.chasing:
                // Handle chasing state or other states here
                // ChangeState(new ChasingState(this, enemyType));
                break;
            case EnemyType.tower:
                // For tower type, transition to the EnemyShoot state
                EnemyShoot enemyShootComponent = GetComponent<EnemyShoot>();
                if (enemyShootComponent != null)
                {
                    ChangeState(enemyShootComponent);
                }
                else
                {
                    Debug.LogWarning("EnemyShoot component not found on the tower type enemy.");
                    // Handle if EnemyShoot component is not found
                }
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

        // Update the flocking behavior
        flockingBehavior.Update();
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
