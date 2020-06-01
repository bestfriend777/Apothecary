using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Footwear Object", menuName = "Inventory System/Items/Equipment/Footwear")]

public class FootwearObject : EquipmentObject
{
    public float defenceBonus = 0;
    public float speedBonus = 0;
    // Add elemental attributes

    public void Awake()
    {
        equipmentLevel = 1;
        equipmentType = EquipmentType.Slacks;
    }
}

