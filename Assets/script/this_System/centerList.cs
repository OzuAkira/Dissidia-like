using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject GM = GameObject.Find("GamMaster");
        PageMaster pageMaster = GM.GetComponent<PageMaster>();
        pageMaster._centerList = gameObject;
    }
}
