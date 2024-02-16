using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            Debug.Log("No neighbors for cohesion");
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;


        Debug.Log($"Cohesion move: {cohesionMove}");

        return cohesionMove;
    }

}
