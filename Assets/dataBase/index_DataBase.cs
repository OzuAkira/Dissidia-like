using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "indexDataBase", menuName = "MyAssets/indexDataBase")]
public class indexDataBase : ScriptableObject
{
    public List<string> index = new List<string>();
}