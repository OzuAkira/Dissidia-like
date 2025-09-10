using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headList : MonoBehaviour
{
    void Start()
    {
        GameObject GM = GameObject.Find("GamMaster");
        PageMaster pageMaster = GM.GetComponent<PageMaster>();
        pageMaster._headList = gameObject;
    }
}
