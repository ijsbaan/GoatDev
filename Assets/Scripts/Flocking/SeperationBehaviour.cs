using UnityEngine;

public class SeperationBehaviour : MonoBehaviour
{
    public float separationRadius = 1f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public Vector3 CalculateSeparation()
    {
        Vector3 separationVector = Vector3.zero;

        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, separationRadius);
        foreach (var neighbor in neighbors)
        {
            if (!neighbor.CompareTag("Untagged"))
            {
                continue;
            }

            if (neighbor.gameObject != gameObject)
            {
                separationVector += transform.position - neighbor.transform.position;
            }
        }

        return separationVector;
    }
}
