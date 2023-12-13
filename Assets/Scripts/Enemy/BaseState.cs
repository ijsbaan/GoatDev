using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{
    public virtual void Enter(EnemyStateMachine machine) { }
    public virtual void Execute(EnemyStateMachine machine) { }
    public virtual void Exit(EnemyStateMachine machine) { }


}
