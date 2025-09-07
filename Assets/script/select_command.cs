using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_command : MonoBehaviour
{
    //public GameObject child;
    void Start()
    {
        StartCoroutine("select_start");
    }
    IEnumerator select_start()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();

        while (rect.anchoredPosition.x > 1000)
        {
            Vector2 pos = rect.anchoredPosition;

            pos.x -= 90;

            rect.anchoredPosition = pos;

            Debug.Log(rect.anchoredPosition.x);

            yield return null;  
        }
    }
}
