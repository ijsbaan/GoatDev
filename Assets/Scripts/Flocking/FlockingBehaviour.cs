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
        Vector3 alignment = alignmentBehavior.CalculateAlignment();
        Vector3 cohesion = cohesionBehavior.CalculateCohesion();
        Vector3 separation = separationBehavior.CalculateSeparation();

        // Combine the flocking rules
        Vector3 combinedForce = alignment + cohesion + separation;

        // Apply the combined force to the Rigidbody
        GetComponent<Rigidbody>().velocity = combinedForce.normalized * speed;

        // Rotate towards the new velocity for smoother movement
        if (GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

