using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Rare,
    Legendary
}

public class ChestItem : MonoBehaviour
{

    public Rarity Rarity;
    public GameObject Item;
    [Range(0, 100)]
    public float dropchancePrecentage;
}
