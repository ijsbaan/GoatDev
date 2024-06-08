using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class AttackMonsterTemp : MonoBehaviour
{
    private float stopTarget = 4;
    [SerializeField] Transform target;
    [SerializeField] GameObject attackBox;
    Vector2 offset = new Vector2(1,0);

    public int randomTimer = 200;
    private float timer;
    private float counter = 0f;

    private Quaternion originalRotation;

    void Start()
    {
        PlayerMovement player  = FindAnyObjectByType<PlayerMovement>();
        if (player != null)
        {
            target = player.transform;
        }
        System.Random random = new System.Random();
        timer = random.Next(randomTimer, randomTimer * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (counter >= timer)
        {
            StartCoroutine(Attack());
            counter = 0;
        }
        else if (distanceToTarget <= stopTarget)
        {
            counter += Time.deltaTime;
        }
    }

    public IEnumerator Attack()
    {
        Vector3 spawnPosition = transform.position + new Vector3(offset.x, offset.y, 0);

        GameObject currentHitbox = Instantiate(attackBox, spawnPosition, Quaternion.identity, transform);
        currentHitbox.GetComponent<DamageColliderByTag>().damage = 1;
        yield return new WaitForSeconds(0.5f);

        Destroy(currentHitbox);
    }
}
