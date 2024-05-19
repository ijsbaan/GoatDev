using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public bool LockRotation;
    public GameObject ObjectToFollow;
    public Vector3 FollowOffset;

    private void Update()
    {
        transform.position = FollowOffset + ObjectToFollow.transform.position;
        if (!LockRotation)
        {
            transform.rotation = ObjectToFollow.transform.rotation;
        }
    }
}
