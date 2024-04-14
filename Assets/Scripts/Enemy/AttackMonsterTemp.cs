using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class AttackMonsterTemp : MonoBehaviour
{
    private float stopTarget = 4;
    [SerializeField] Transform target;

    public int randomTimer = 200;
    private float timer;
    private float counter = 0f;

    void Start()
    {
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

    private IEnumerator Attack()
    {
        Debug.Log("ATTACKS");

        yield return new WaitForSeconds(0.5f);
        
    }
}
