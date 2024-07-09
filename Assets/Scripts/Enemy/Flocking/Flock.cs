using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Flock : AttackState
{
    public FlockAgent agentPrefab;
    [HideInInspector]
    public List<FlockAgent> agents = new List<FlockAgent>();
    public CompositeBehaviour behaviour;

    public int spawnChildren = 1;
    public int maxChildren = 10;
    const float AgentDensity = 0.08f;

    public int counter = 0;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 3f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 1f;

    [SerializeField] private LayerMask contextLayers;


    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    public override void EnterState()
    {
        enabled = true;
        SetTargetToHunt(target);
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
    }

    public override void UpdateState()
    {
        if (agents.Count < maxChildren) counter++;
        if (counter > 1000 && agents.Count < maxChildren)
        {
            makeChildren();
            counter = 0;
        }

        foreach (FlockAgent agent in agents)
        {

            List<Transform> context = GetNearbyObjects(agent);

            Vector2 move = behaviour.CalculateMove(agent, context, this);

            move *= driveFactor;

            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
        base.UpdateState();
    }

    private void makeChildren()
    {
        for (int i = 0; i < spawnChildren; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, new Vector2(transform.position.x,transform.position.y) + Random.insideUnitCircle * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent" + i;
            newAgent.Owner = this;
            agents.Add(newAgent);
        }
    }
    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D col in contextColliders)
        {
            if (col != agent.AgentCollider && (contextLayers & (1 << col.gameObject.layer)) != 0)
            {
                context.Add(col.transform);
            }
        }
        return context;
    }

    public void SetTargetToHunt(GameObject target)
    {
        Debug.Log(target);
        foreach(var behavior in behaviour.behaviours)
        {
            if(behavior is HuntBehaviour hunt)
            {
                hunt.SetTarget(target);
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        SetTargetToHunt(this.gameObject);
    }
}

