using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class story_1 : menuScript
{
    public override void select()
    {
        Debug.Log("Farway");
        StartCoroutine("Load_Scene");
    }
    IEnumerator Load_Scene()
    {

        //yield return new WaitForSeconds(0.2f);
        Debug.Log("tae");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("story_1");
        
        Debug.Log("test");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
