using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class TriggerHazard : MonoBehaviour
{
    public int damage;

    GameObject player;
    PlayerStats stats;

    void OnTriggerEnter2D(Collider2D collider)
    {
        player = GameObject.Find("PlayerBody");

        if (player == null)
        {
            UnityEngine.Debug.Log("Could not find player");
        }

        stats = player.GetComponent<PlayerStats>();

        

        if (stats != null)
        {
            stats.health = stats.health - damage;
        }
        else
        {
            UnityEngine.Debug.Log("could not find player stats");
        }
    }

    
}
