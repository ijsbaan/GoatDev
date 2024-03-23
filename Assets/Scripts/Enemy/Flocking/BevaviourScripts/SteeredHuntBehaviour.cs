using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredSpyke")]
public class SteeredHuntBehaviour : FlockBehaviour
{
    private GameObject target;

    Vector2 currentVelocity;
    public float agentSmoothTime;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            if (target == null)
                return agent.transform.up;
        }

        Vector2 huntMove = ((Vector2)target.transform.position - (Vector2)agent.transform.position).normalized;

        return huntMove;
    }
}
