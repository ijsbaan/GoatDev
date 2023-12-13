using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    [SerializeField]
    EnemyState _currentState = EnemyState.Idle;

    BaseState _state;

    void GetCurrentState()
    {
        switch (_currentState)
        {
            case EnemyState.Idle:
                _state = new IdleState();
                break;
            case EnemyState.Chase:
                break;
            case EnemyState.Attack:
                break;
            default:
                break;


        }
    }

    private void Awake()
    {
        //_state = GetCurrentState();
    }

    private void Start()
    {
        _state.Enter(this);
    }

    private void Update()
    {
        _state.Execute(this);
    }

}
