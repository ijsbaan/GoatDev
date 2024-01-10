using UnityEngine;

public class AlignmentBehaviour : MonoBehaviour
{
    public float neighborRadius = 2f;

    public Vector3 CalculateAlignment()
    {
        Vector3 averageVelocity = Vector3.zero;
        int count = 0;

        Collider[] neighbors = Physics.OverlapSphere(transform.position, neighborRadius);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.gameObject != gameObject)
            {
                averageVelocity += neighbor.GetComponent<Rigidbody>().velocity;
                count++;
            }
        }

        if (count > 0)
        {
            averageVelocity /= count;
            return (averageVelocity - GetComponent<Rigidbody>().velocity) * 0.1f;
        }

        return Vector3.zero;
    }
}
