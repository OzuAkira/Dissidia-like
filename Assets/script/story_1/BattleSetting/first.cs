using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class first : menuScript
{
    public GameObject characterList;
    //public GameObject cursor;
    void Awake()
    {
        characterList.SetActive(false);
    }
    public override void select()
    {
        //Debug.Log("activ_action");
        characterList.SetActive(true);
    }
    void Update()
    {
        if(characterList.activeSelf == true) gameObject.SetActive(false);
    }
}
