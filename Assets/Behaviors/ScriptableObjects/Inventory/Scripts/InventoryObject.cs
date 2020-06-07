using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Versioning;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    private ItemDatabaseObject database;
    public List<InventorySlot> inventoryContainer = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }

    public void AddItem(ItemObject _item, int _amount)
    {
        // here if the InventoryContainer is size 0 then the for loop is skipped
        // maybe for each would work better
        for (int i = 0; i < inventoryContainer.Count; i++)
        {
            if (inventoryContainer[i].item == _item)
            {
                inventoryContainer[i].AddAmount(_amount);
                return;
            }
        }
        inventoryContainer.Add(new InventorySlot(database.GetId[_item], _item, _amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

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

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < inventoryContainer.Count; i++)
        {
            inventoryContainer[i].item = database.GetItem[inventoryContainer[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {

    }

}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;

    public InventorySlot(int _ID, ItemObject _item, int _amount)
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