using System.Collections;
using System.Collections.Generic;
using UnityEditor;  
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;
    public void OnAfterDeserialize()
    {

    }

    public void OnBeforeSerialize()
    {
        if(item != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
            gameObject.name = item.name;
            EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
        }

        //EditorUtility.SetDirty(item.name);

    }

}
