using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slacks Object", menuName = "Inventory System/Items/Equipment/Slacks")]

public class SlacksObject : EquipmentObject
{
    public float defenceBonus = 0;
    // Add elemental attributes

    public void Awake()
    {
        equipmentLevel = 1;
        equipmentType = EquipmentType.Slacks;
    }
}
