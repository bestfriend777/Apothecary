using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Hat,
    Shirt,
    Gloves,
    Slacks,
    Footwear
}

public abstract class EquipmentObject : ItemObject
{
    public EquipmentType equipmentType;
    public int equipmentLevel;
    
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
