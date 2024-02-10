using UnityEngine;

public class FlockingBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 1f;
    [SerializeField] Rigidbody2D rb;
    public bool enableFlocking = true;

    [SerializeField] private AllignmentBehaviour alignmentBehavior;
    [SerializeField] private CohesionBehaviour cohesionBehavior;
    [SerializeField] private SeperationBehaviour separationBehavior;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alignmentBehavior = GetComponent<AllignmentBehaviour>();
        cohesionBehavior = GetComponent<CohesionBehaviour>();
        separationBehavior = GetComponent<SeperationBehaviour>();
        if (rb == null || alignmentBehavior == null || cohesionBehavior == null || separationBehavior == null)
        {
            Debug.LogError("One or more required components are missing.");
        }
    }

    public void Update()
    {
        if (enableFlocking)
        {
            // Flocking rules
            Vector2 alignment = alignmentBehavior.CalculateAlignment();
            Vector2 cohesion = cohesionBehavior.CalculateCohesion();
            Vector2 separation = separationBehavior.CalculateSeparation();

            // Combine the flocking rules
            Vector2 combinedForce = alignment + cohesion + separation;

            // Apply the combined force to the Rigidbody
            rb.velocity = combinedForce.normalized * speed;

            // Rotate towards the new velocity for smoother movement
            if (rb.velocity != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(rb.velocity, Vector2.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}

