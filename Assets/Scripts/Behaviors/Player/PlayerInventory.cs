using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryCanvas;

    private Boolean isVisible = true;

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var pickupItem = otherCollider.GetComponent<GroundItem>();

        if(pickupItem)
        {
            inventory.AddItem(new Item(pickupItem.item), 1);
            Destroy(otherCollider.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            UnityEngine.Debug.Log("Saved");

        }
        if (Input.GetKeyDown("l"))
        {
            inventory.Load();
            UnityEngine.Debug.Log("Loaded");

        }
        if (Input.GetKeyDown("e"))
        {
            //UIImage inventory = inventoryCanvas.GetComponentInChildren(UIImage, true);
            //inventory.Image.enabled = false;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.inventoryContainer.Items = new InventorySlot[20];
    }
}
