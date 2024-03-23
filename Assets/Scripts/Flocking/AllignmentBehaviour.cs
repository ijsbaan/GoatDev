using UnityEngine;

public class AllignmentBehaviour : MonoBehaviour
{
    public float neighborRadius = 1f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public Vector3 CalculateAlignment()
    {
        Vector2 averageVelocity = Vector3.zero;
        int count = 0;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, neighborRadius);
        foreach (var neighbor in neighbors)
        {
            if (!neighbor.CompareTag("Untagged"))
            {
                continue;
            }

            Rigidbody2D neighborRb2D = neighbor.GetComponent<Rigidbody2D>();
            if (neighborRb2D != null && neighborRb2D != rb2D)
            {
                averageVelocity += neighborRb2D.velocity;
                count++;
            }
        }

        if (count > 0)
        {
            averageVelocity /= count;
            return (averageVelocity - rb2D.velocity) * 0.1f;
        }

        return Vector3.zero;
    }
}
