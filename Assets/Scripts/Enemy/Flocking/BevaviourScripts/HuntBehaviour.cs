using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Spyke")]
public class HuntBehaviour : FlockBehaviour
{
    [SerializeField] private GameObject target;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (agent == null)
            return agent.transform.up;

        Vector2 huntMove = Vector2.zero;
            
        huntMove += (Vector2) (target.transform.position - agent.transform.position);

        huntMove = huntMove.normalized;

        return huntMove;
    }
}
