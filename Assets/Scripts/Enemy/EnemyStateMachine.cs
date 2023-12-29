using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IEnemyState currentState;

    // Set the initial state (e.g., in Start() method)
    private void Start()
    {
        ChangeState(new IdleState(this));
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