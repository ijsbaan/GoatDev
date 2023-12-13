using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var forward = transform.forward;
        forward.z = 0;
        this.gameObject.transform.position += forward  * Time.deltaTime * projectileSpeed;
    }
}
