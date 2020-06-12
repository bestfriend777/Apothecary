using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVanish : MonoBehaviour
{
    public SpriteRenderer renderer;
    GameObject bush;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        bush = GameObject.Find("bush_vanish");

        renderer.enabled = false;
        bush.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        renderer.enabled = true;
        bush.GetComponent<BoxCollider2D>().enabled = true;

    }
}
