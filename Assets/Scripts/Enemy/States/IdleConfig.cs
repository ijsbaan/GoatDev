using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/IdleConfig")]
public class IdleConfig : ScriptableObject
{
    public AttackCheckMethod attackCheckMethod;
    public float idleDuration;
    public float detectionRadius;
    
}

