using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first : menuScript
{
    public GameObject characterList;
    public GameObject myObj;
    void Awake()
    {
        characterList.SetActive(false);
    }
    public override void select()
    {
        characterList.SetActive(true);
    }
    void Update()
    {
        if(characterList.activeSelf == true) myObj.SetActive(false);
    }
}
