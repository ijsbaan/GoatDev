using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Seperation")]
public class SeperationBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, maintain current alignment
        if (context.Count == 0)
            return agent.transform.up;

        //add all points together and average
        Vector2 seperationMove = Vector2.zero;
        int nAvoid = 0;
        foreach (Transform item in context)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                seperationMove += (Vector2) (agent.transform.position - item.position);
            }
        }

        if(nAvoid > 0)
        {
            seperationMove/= nAvoid;
        }

        return seperationMove;
    }
}
