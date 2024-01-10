using UnityEngine;

public class FlockingBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 1f;

    private AlignmentBehaviour alignmentBehavior;
    private CohesionBehaviour cohesionBehavior;
    private SeparationBehaviour separationBehavior;

    void Start()
    {
        alignmentBehavior = GetComponent<AlignmentBehaviour>();
        cohesionBehavior = GetComponent<CohesionBehaviour>();
        separationBehavior = GetComponent<SeparationBehaviour>();
    }

    public void Update()
    {
        // Flocking rules
        Vector2 alignment = alignmentBehavior.CalculateAlignment();
        Vector2 cohesion = cohesionBehavior.CalculateCohesion();
        Vector2 separation = separationBehavior.CalculateSeparation();

        // Combine the flocking rules
        Vector2 combinedForce = alignment + cohesion + separation;

        // Apply the combined force to the Rigidbody
        GetComponent<Rigidbody2D>().velocity = combinedForce.normalized * speed;

        // Rotate towards the new velocity for smoother movement
        if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(GetComponent<Rigidbody2D>().velocity, Vector2.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

