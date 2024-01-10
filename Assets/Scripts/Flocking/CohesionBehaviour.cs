using UnityEngine;

public class CohesionBehaviour : MonoBehaviour
{
    public float neighborRadius = 2f;

    public Vector3 CalculateCohesion()
    {
        Vector3 averagePosition = Vector3.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, neighborRadius);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.gameObject != gameObject)
            {
                averagePosition += neighbor.transform.position;
                count++;
            }
        }

        if (count > 0)
        {
            averagePosition /= count;
            return (averagePosition - transform.position) * 0.1f;
        }

        return Vector3.zero;
    }
}
