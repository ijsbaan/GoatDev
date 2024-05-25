using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemySpike : MonoBehaviour, IEnemyState
{
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject Indicator;
    GameObject indicator;
    public GameObject player;
    private Vector3 targetPosition;
    [SerializeField] bool spawnSpike;
    [SerializeField] float timeBetweenSpikes;
    [SerializeField] float timeTillSpike;
    [SerializeField] float pauseTime;
    [SerializeField] float spikeDuration;
    bool pausing;
    [SerializeField] SpriteRenderer sprite;
    public float detectionRadius;
    public EnemyController controller;
    public DryadIdleState idle;

    [SerializeField] bool playerNear;

    IEnumerator SummonSpike()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(timeBetweenSpikes);
        indicator = Instantiate(Indicator, targetPosition, Quaternion.identity, transform);
        Vector3 previousPos = indicator.transform.position;
        yield return new WaitForSeconds(timeTillSpike);
        pausing = true;
        yield return new WaitForSeconds(pauseTime);
        var spike = Instantiate(Projectile, indicator.transform.position, Quaternion.identity, transform);
        Destroy(indicator);
        pausing = false;
        spawnSpike = true;
        yield return new WaitForSeconds(spikeDuration);
        Destroy(spike);
    }

    public void EnterState()
    {
        spawnSpike = true;
        pausing = false;
    }

    public void UpdateState()
    {
        if (spawnSpike)
        {
            spawnSpike = false;
            StartCoroutine("SummonSpike");
        }
        if (indicator != null && player != null && !pausing)
        {
            targetPosition = player.transform.position;
            // Smoothly move the indicator towards the target position
            indicator.transform.position = Vector3.Lerp(targetPosition, indicator.transform.position, 0.2f);
        }

        // Check if the player is within the detection radius
        bool playerDetected = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider == player.GetComponent<Collider2D>())
            {
                playerDetected = true;
                break;
            }
        }
        playerNear = playerDetected;

        // If the player is not near, change the state to idle
        if (!playerNear)
        {
            controller.ChangeState(idle);
        }
    }

    public void ExitState()
    {
        sprite.color = Color.green;
        spawnSpike = false;
    }
}
