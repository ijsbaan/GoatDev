using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    public int spawnChildren = 1;
    const float AgentDensity = 0.08f;

    public int counter = 0;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;  

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

        //for (int i = 0; i < startingCount; i++)
        //{
        //    FlockAgent newagent = Instantiate(agentPrefab, Random.insideUnitCircle * startingCount * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
        //    newagent.name = "Agent" + i;
        //    agents.Add(newagent);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if(agents.Count < 5) counter++;
        
        if(counter > 1000 && agents.Count < 5)
        { 
            makeChildren();
            counter = 0;
        }

        foreach (FlockAgent agent in agents)
        {
            //if (agent != null)
            //{
            //    continue;
            //}
            List<Transform> context = GetNearbyObjects(agent);

            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector2 move = behaviour.CalculateMove(agent, context, this);

            move *= driveFactor;
            
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    private void makeChildren()
    {
        for (int i = 0; i < spawnChildren; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);
        }
    }
    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
            
        foreach(Collider2D col in contextColliders)
        {
            if(col != agent.AgentCollider)
            {
                context.Add(col.transform);
            }
        }
        return context;
    }
}

