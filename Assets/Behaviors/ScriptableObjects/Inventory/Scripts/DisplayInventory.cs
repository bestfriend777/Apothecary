using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACING;
    public int Y_SPACING;
    public int COLUMN_COUNT;

    Dictionary<InventorySlot, GameObject> displayedItems = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.inventoryContainer.Count; i++)
        {
            if(displayedItems.ContainsKey(inventory.inventoryContainer[i]))
            {
                displayedItems[inventory.inventoryContainer[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.inventoryContainer[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.inventoryContainer[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.inventoryContainer[i].amount.ToString("n0");
                displayedItems.Add(inventory.inventoryContainer[i], obj);
            }
        }
  
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.inventoryContainer.Count; i++)
        {
            var obj = Instantiate(inventory.inventoryContainer[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.inventoryContainer[i].amount.ToString("n0");
            displayedItems.Add(inventory.inventoryContainer[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACING * (i % COLUMN_COUNT)), Y_START + ((-Y_SPACING * (i / COLUMN_COUNT))), 0.0f);
    }
}
