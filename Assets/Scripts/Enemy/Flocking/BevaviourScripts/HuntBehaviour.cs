using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Spyke")]
public class HuntBehaviour : FlockBehaviour
{
    public float stoppingDistance = 5f; // Adjust this distance as per your requirement
    public GameObject target;


    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {


        if (target == null || agent == null)
        {
            return agent.transform.up;
        }

        Vector2 huntMove = Vector2.zero;

        float distanceToTarget = Vector2.Distance(agent.transform.position, target.transform.position);

        if (distanceToTarget > stoppingDistance)
        {
            huntMove = (Vector2)(target.transform.position - agent.transform.position).normalized;
        }

        return huntMove;
    }
}
