using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterSelect : MonoBehaviour
{
    public GameObject[] memberlist;
    void Update()
    {
        for(int i=0;i<memberlist.Length;i++)
        {
            if(memberlist[i].activeSelf == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
