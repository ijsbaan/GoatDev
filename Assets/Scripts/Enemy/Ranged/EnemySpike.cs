using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemySpike : AttackState, IEnemyState
{
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject Indicator;
    GameObject indicator;
    GameObject spike;
    public GameObject player;
    private Vector3 targetPosition;
    [SerializeField] bool spawnSpike;
    [SerializeField] float timeBetweenSpikes;
    [SerializeField] float timeTillSpike;
    [SerializeField] float pauseTime;
    [SerializeField] float spikeDuration;
    bool pausing;
    [SerializeField] SpriteRenderer sprite;

    IEnumerator SummonSpike()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(timeBetweenSpikes);
        indicator = Instantiate(Indicator, targetPosition, Quaternion.identity, transform);
        yield return new WaitForSeconds(timeTillSpike);
        pausing = true;
        yield return new WaitForSeconds(pauseTime);
        spike = Instantiate(Projectile, indicator.transform.position, Quaternion.identity, transform);
        Destroy(indicator);
        pausing = false;
        spawnSpike = true;
        yield return new WaitForSeconds(spikeDuration);
        Destroy(spike);
    }

    public override void EnterState()
    {
        spawnSpike = true;
        pausing = false;
        player = target;
    }

    public override void UpdateState()
    {
        base.UpdateState();
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

    public override void ExitState()
    {
        spawnSpike = false;
        StopAllCoroutines();
        sprite.color = Color.green;
        if(indicator != null)
        {
            Destroy(indicator); indicator = null;
        }
        if(spike != null)
        {
            Destroy(spike); spike = null;
        }
    }
}
