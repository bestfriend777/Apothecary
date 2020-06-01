using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{
    public int itemID;
    public SpriteRenderer renderer;

    bool isPickedUp = false;
    GameObject player;
    Inventory inventoryScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isPickedUp)
        {
            // disable sprite renderer and set ispickedup to true
            renderer.enabled = false;
            isPickedUp = true;

            // TODO: create a tag system and find gameobject with the "Player" tag instead
            // better for memory and more reliable
            player = GameObject.Find("PlayerBody");

            inventoryScript = player.GetComponent<Inventory>();

            // here we check if inventoryScript has been set to an Inventory component. 
            // If player.GetComponent<Inventory>() fails to find the Inventory 
            // component, then inventoryScript will be set equal to "null"
            if(inventoryScript != null)
            {
                UnityEngine.Debug.Log("found inventory of object: " + player.name);
                inventoryScript.AddItem(itemID);
            }
        }
    }
}
