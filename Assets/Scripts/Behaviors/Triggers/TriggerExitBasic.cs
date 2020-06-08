using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class TriggerExitBasic : MonoBehaviour
{
    public int sceneID;

    void OnTriggerEnter2D(Collider2D collider)
    {
        UnityEngine.Debug.Log("Trigger: TRUE");
        SceneManager.LoadSceneAsync(sceneID);
    }
}
