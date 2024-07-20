using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileActiveTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var forward = transform.right;
        forward.z = 0;
        this.gameObject.transform.position += forward  * Time.deltaTime * projectileSpeed;
        if(timer > projectileActiveTime)
        {
            Destroy(gameObject);
        }
    }
}
