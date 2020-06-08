using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = " New Refill Object", menuName = "Inventory System/Items/refill")]

public enum RefillType
{
    Health,
    Mana,
    Juice
}

public abstract class RefillObject : ItemObject
{
    public int restoreValue;
    public RefillType refillType;

    public void Awake()
    {
        type = ItemType.Refill;
    }
}
