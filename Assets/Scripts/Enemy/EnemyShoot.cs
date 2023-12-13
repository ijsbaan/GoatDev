using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject Projectile;
    [SerializeField] float projectilespeed;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] bool shootBullet;
    [SerializeField] float timeBetweenShots;

    private void Start()
    {
    }


    private void FixedUpdate()
    {
        if (shootBullet)
        {
            shootBullet = false;
            StartCoroutine("shootAtTarget");
        }

    }

    IEnumerator shootAtTarget()
    {
        ShootAtPosition(targetPosition);
        yield return new WaitForSeconds(timeBetweenShots);
        shootBullet = true;
    }
    void ShootAtPosition(Vector3 targetposition)
    {
        Vector3 distanceToLocation = (targetposition - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(distanceToLocation);
        var projectile = Instantiate(Projectile,transform.position,rotation,transform);
    }
}
