using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword Object", menuName = "Inventory System/Items/Equipment/Sword")]

public class SwordObject : EquipmentObject
{

    public void Awake()
    {
        equipmentType = EquipmentType.Sword;
    }
}

