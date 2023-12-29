using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemyShoot : MonoBehaviour, IEnemyState
{
    [SerializeField] GameObject Projectile;
    float zPos = 2;
    [SerializeField] Vector2 targetPosition;
    [SerializeField] bool shootBullet;
    [SerializeField] float timeBetweenShots;

    IEnumerator shootAtTarget()
    {
        ShootAtPosition(targetPosition);
        yield return new WaitForSeconds(timeBetweenShots);
        shootBullet = true;
    }
    public void ShootAtPosition(Vector3 targetposition)
    {
        Vector3 distanceToLocation = (targetposition - transform.position).normalized;
        distanceToLocation.z = zPos;
        Quaternion rotation = Quaternion.LookRotation(distanceToLocation);
        var projectile = Instantiate(Projectile,transform.position,rotation,transform);
    }

    public void EnterState()
    {
        shootBullet = true;
    }

    public void UpdateState()
    {
        if (shootBullet)
        {
            shootBullet = false;
            StartCoroutine("shootAtTarget");
        }
    }

    public void ExitState()
    {
        throw new NotImplementedException();
    }
}
