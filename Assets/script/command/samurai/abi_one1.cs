using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static prameterDB;

public class abi_one : abilities
{
    [SerializeField] enemyTable enemyTable;
    Text _Text;
    private void Start()
    {
        var cildObj = transform.GetChild(0);
        _Text = cildObj.GetComponent<Text>();
        //_Text.text = 
    }
    public override void Attack(int target_index)
    {
       // enemyTable._enemyDB[target_index]


    }
    public override void information()
    {
        Debug.Log("Log");
    }
}
