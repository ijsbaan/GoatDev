using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class EnemyShoot : AttackState, IEnemyState
{
    [SerializeField] GameObject Projectile;
    float zPos = 1;
    [SerializeField] Vector2 targetPosition;
    [SerializeField] bool shootBullet;
    [SerializeField] float timeBetweenShots;

    IEnumerator shootAtTarget()
    {
        ShootAtPosition(targetPosition);
        yield return new WaitForSeconds(timeBetweenShots);
        shootBullet = true;
    }
    public void ShootAtPosition(Vector2 targetPosition)
    {
        // Calculate the direction from the current position to the target position
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Calculate the angle between the current position and the target position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a rotation based on the angle
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Instantiate the projectile at the current position with the calculated rotation
        var projectile = Instantiate(Projectile, transform.position, rotation);
    }

    public override void EnterState()
    {
        shootBullet = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        targetPosition = target.transform.position;
        if (shootBullet)
        {
            shootBullet = false;
            StartCoroutine("shootAtTarget");
        }
    }

    public override void ExitState()
    {
    }
}
