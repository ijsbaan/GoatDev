using UnityEngine;

public class AllignmentBehaviour : MonoBehaviour
{
    public float neighborRadius = 1f;

    public Vector3 CalculateAlignment()
    {
        Vector2 averageVelocity = Vector3.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, neighborRadius);
        foreach (var neighbor in neighbors)
        {
            if(neighbor.tag == "Untagged" || neighbor.tag == "")
            {
                break;
            }
            if (neighbor.gameObject != gameObject)
            {
                averageVelocity += neighbor.GetComponent<Rigidbody2D>().velocity;
                count++;
            }
        }

        if (count > 0)
        {
            averageVelocity /= count;
            return (averageVelocity - GetComponent<Rigidbody2D>().velocity) * 0.1f;
        }

        return Vector3.zero;
    }
}
