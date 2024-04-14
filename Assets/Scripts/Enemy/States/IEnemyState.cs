using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    abstract void EnterState();
    abstract void UpdateState();
    abstract void ExitState();
}
