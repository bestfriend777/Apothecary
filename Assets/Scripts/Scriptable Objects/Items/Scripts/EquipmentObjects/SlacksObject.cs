using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slacks Object", menuName = "Inventory System/Items/Equipment/Slacks")]

public class SlacksObject : EquipmentObject
{

    public void Awake()
    {
        equipmentType = EquipmentType.Slacks;
    }
}
