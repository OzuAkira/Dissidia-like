using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class story_1 : menuScript
{
    public override void select()
    {
        StartCoroutine("Load_S_Scene");
    }
    IEnumerable Load_S_Scene()
    {

        yield return new WaitForSeconds(0.2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("");
        while (asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
