using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class TriggerTest : MonoBehaviour
{
    public SpriteRenderer renderer;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        renderer.enabled = false;
        UnityEngine.Debug.Log("trigger set TRUE");
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        renderer.enabled = true;
        UnityEngine.Debug.Log("trigger set FALSE");
    }
}
