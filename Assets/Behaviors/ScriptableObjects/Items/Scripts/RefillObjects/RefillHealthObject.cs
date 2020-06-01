using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RefillHealth Object", menuName = "Inventory System/Items/Refills/Health")]

public class RefillHealthObject : RefillObject
{
    
    public void Awake()
    {
        restoreValue = 10;
        refillType = RefillType.Health;
    }
}
