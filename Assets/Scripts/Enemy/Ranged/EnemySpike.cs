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
    [SerializeField] PlayerMovement player;
    private Vector3 targetPosition;
    [SerializeField] bool spawnSpike;
    [SerializeField] float timeBetweenSpikes;
    [SerializeField] float timeTillSpike;
    [SerializeField] float pauseTime;
    [SerializeField] float spikeDuration;
    bool pausing;

    IEnumerator SummonSpike()
    {
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
    }

    public void ExitState()
    {
        throw new NotImplementedException();
    }
}
