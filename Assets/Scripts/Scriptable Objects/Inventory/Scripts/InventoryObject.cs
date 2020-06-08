using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory inventoryContainer;

    public void AddItem(Item _item, int _amount)
    {
        if (_item.buffs.Length > 0)
        {
            inventoryContainer.Items.Add(new InventorySlot(_item.Id, _item, _amount));
            return;
        }

        for (int i = 0; i < inventoryContainer.Items.Count; i++)
        {
            if (inventoryContainer.Items[i].item.Id == _item.Id)
            {
                inventoryContainer.Items[i].AddAmount(_amount);
                return;
            }
        }
        inventoryContainer.Items.Add(new InventorySlot(_item.Id, _item, _amount));
    }

    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }

    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        inventoryContainer = new Inventory();
    }

    public void OnAfterDeserialize()
    {
        //ItemObject itemObject = new ItemObject();

        //for (int i = 0; i < inventoryContainer.Items.Count; i++)
        //{
        //    inventoryContainer.Items[i].item = new Item(database.GetItem[i]);
        //    //inventoryContainer.Items[i].item = new Item(itemObject);
        //}
    }

    public void OnBeforeSerialize()
    {

    }

}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();  
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;

    public InventorySlot(int _ID, Item _item, int _amount)
    {
        ID = _ID;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
        UnityEngine.Debug.Log("added " + value + " item(s)");
    }
}