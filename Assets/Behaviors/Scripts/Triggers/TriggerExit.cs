using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerExit : MonoBehaviour
{
    public int sceneID;

    public Animator transition;
    public float transitionTime = 1.0f;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        UnityEngine.Debug.Log("Exit Triggered. Load scene " + sceneID);
        StartCoroutine(ExitScene(sceneID));
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        UnityEngine.Debug.Log("trigger: EXIT");
    }

    IEnumerator ExitScene(int id)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(id);
    }
}
