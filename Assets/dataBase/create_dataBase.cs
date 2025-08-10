using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharactorAsset", menuName = "MyAssets/CharactorAsset")]
public class create_dataBase : ScriptableObject
{
    public string CharactorID;
    public string CharactorName;

    public int HP;
    public int attack;
    public int defense;
    public int speed;

    public Sprite[] image;
}