using UnityEngine;

public class SeperationBehaviour : MonoBehaviour
{
    public float separationRadius = 1f;

    public Vector3 CalculateSeparation()
    {
        Vector3 separationVector = Vector3.zero;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, separationRadius);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.tag == "Untagged" || neighbor.tag == "")
            {
                break;
            }
            if (neighbor.gameObject != gameObject)
            {
                separationVector += transform.position - neighbor.transform.position;
            }
        }

        return separationVector;
    }
}
