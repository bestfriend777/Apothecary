using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Footwear Object", menuName = "Inventory System/Items/Equipment/Footwear")]

public class FootwearObject : EquipmentObject
{
  
    public void Awake()
    {
        equipmentType = EquipmentType.Footwear;
    }
}

