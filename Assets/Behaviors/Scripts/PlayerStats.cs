using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using UnityEngine;

using static UnityEngine.Debug;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
           Destroy(gameObject);
        }
    }
}
