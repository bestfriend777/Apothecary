using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACING;
    public int Y_SPACING;
    public int COLUMN_COUNT;

    Dictionary<GameObject, InventorySlot> displayedItems = new Dictionary<GameObject, InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }


    public void UpdateSlots()
    {
        foreach(KeyValuePair<GameObject, InventorySlot> _slot in displayedItems)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                {
                    _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                    _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                    _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
            }
        }
    }
    public void CreateSlots()
    {
        displayedItems = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.inventoryContainer.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            displayedItems.Add(obj, inventory.inventoryContainer.Items[i]);
        }

        
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACING * (i % COLUMN_COUNT)), Y_START + ((-Y_SPACING * (i / COLUMN_COUNT))), 0.0f);
    }
}
