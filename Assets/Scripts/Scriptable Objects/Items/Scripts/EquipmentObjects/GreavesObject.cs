using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Greaves Item", menuName = "Inventory System/Items/Equipment/Greaves")]

public class GreavesObject : EquipmentObject
{
    public void Awake()
    {
        equipmentType = EquipmentType.Greaves;
    }
}
