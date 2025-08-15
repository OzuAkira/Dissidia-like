using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharactorAsset", menuName = "MyAssets/CharactorAsset")]
public class create_dataBase : ScriptableObject
{
    public string ID;
    public string Name;

    public int HP;
    public int attack;
    public int defense;
    public int speed;

    public Sprite Icon;
    public Sprite[] image;
}

[CreateAssetMenu(fileName = "EnemyAsset", menuName = "MyAssets/EnemyAsset")]
public class enemy_dataBase : ScriptableObject
{
    public string ID;
    public string Name;

    public int HP;
    public int attack;
    public int defense;
    public int speed;

    public Sprite Icon;
    public Sprite[] image;
}