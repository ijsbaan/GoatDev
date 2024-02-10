using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();

    public FlockBehaviour behviour;

    [Range(10, 500)] public int startingCount = 250;
    const float agentDensity = 0.08f;

    [Range(1f, 100f)] public float driveFactor = 10f;

    [Range(1f, 100f)] public float maxSpeed = 5f;

    [Range(1f, 10f)] public float neighbourRadius = 1.5f;

    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            FlockAgent newagent = Instantiate(agentPrefab, Random.insideUnitCircle * startingCount * agentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newagent.name = "Agent" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
