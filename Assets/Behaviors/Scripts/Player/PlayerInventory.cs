 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var pickupItem = otherCollider.GetComponent<Item>();

        if(pickupItem)
        {
            inventory.AddItem(pickupItem.item, 1);
            UnityEngine.Debug.Log("Added item");    
            Destroy(otherCollider.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.inventoryContainer.Clear();
    }
}
