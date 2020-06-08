using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
     TODO: 
        1: Create a pool of images that can be called to the inventoryUI based on the item id passed into AddItem()
        2: Create a "highlighted" sprite that shows which slot is currently selected. 
        3: Add inventory grid movement for "up, down, left, right" key input (use Input.GetKeyDown("keyName") function)
        4: replace "inventory" array with an actual item database. uiSlotIsActive will probably be absorbed by this
        5: Add scene to scene permanance of inventory. Probably using an xml or json format database.
*/

public class OldInventory : MonoBehaviour
{
    public Canvas uiCanvas;
    public Image[] uiSlotImages;
    public Image[] uiSlotHighlights;

    int[] inventory = new int[4];
    bool[] uiSlotIsActive = new bool[4];
    bool isCanvasVisible = false;

    int nextSlot = 0;
    
   public void AddItem(int itemID)
   {
        inventory[nextSlot] = itemID;

        UnityEngine.Debug.Log("item " + itemID + " added to inventory");
        UnityEngine.Debug.Log("Added to slot: " + nextSlot);

        AddToSlot(nextSlot, itemID);

        // "++" is a shortcut to add 1 to an int. the syntax is the same as "nextSlot = nextSlot + 1"
        // this is also called "iteration" or "iterating" an int
        nextSlot++;
   }

    void AddToSlot(int slot, int id)
    {

        if(!uiSlotIsActive[slot])
        {
            uiSlotImages[slot].enabled = true;
            uiSlotIsActive[slot] = true;
        }

    }

    void UseSlot(int slot, int id)
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isCanvasVisible)
            {
                uiCanvas.enabled = false;
                isCanvasVisible = false;
            }
            else
            {
                uiCanvas.enabled = true;
                isCanvasVisible = true;
            }
        }
        
        if(isCanvasVisible)
        {
            if(Input.GetKeyDown("1"))
            {
                if (uiSlotIsActive[0])
                {
                    uiSlotImages[0].enabled = false;
                    uiSlotIsActive[0] = false;
                    nextSlot--;
                }
            }
            if (Input.GetKeyDown("2"))
            {
                if (uiSlotIsActive[1])
                {
                    uiSlotImages[1].enabled = false;
                    uiSlotIsActive[1] = false;
                    nextSlot--;

                }
            }
            if (Input.GetKeyDown("3"))
            {
                if (uiSlotIsActive[2])
                {
                    uiSlotImages[2].enabled = false;
                    uiSlotIsActive[2] = false;
                    nextSlot--;
                }
            }
            if (Input.GetKeyDown("4"))
            {
                if (uiSlotIsActive[3])
                {
                    uiSlotImages[3].enabled = false;
                    uiSlotIsActive[3] = false;
                    nextSlot--;
                }
            }

        }

        // CONVENTIONAL INPUT NAMES

        //Letter keys     a, b, c…
        //Number keys     1, 2, 3…
        //Arrow keys  up, down, left, right
        //Numpad keys[1], [2], [3], [+], [equals]…
        //Modifier keys   right shift, left shift, right ctrl, left ctrl, right alt, left alt, right cmd, left cmd
        //Special keys backspace, tab, return, escape, space, delete, enter, insert, home, end, page up, page down
        //Function keys   f1, f2, f3…

    }
}
