using UnityEngine;

public class SeparationBehaviour : MonoBehaviour
{
    public float separationRadius = 1f;

    public Vector3 CalculateSeparation()
    {
        Vector3 separationVector = Vector3.zero;

        Collider[] neighbors = Physics.OverlapSphere(transform.position, separationRadius);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.gameObject != gameObject)
            {
                separationVector += transform.position - neighbor.transform.position;
            }
        }

        return separationVector;
    }
}