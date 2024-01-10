using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : IEnemyState
{
    
    private readonly EnemyController enemyController;
    private readonly EnemyType enemyType;
    private int distance;
    private int fieldofView;

    public ChasingState(EnemyController controller, EnemyType type, GameObject player)
    {
        enemyController = controller;
        enemyType = type;
    }

    public void EnterState()
    {

    }

    public void UpdateState()
    {
        distance = 
    }

    public void ExitState()
    {
        
    }
}
