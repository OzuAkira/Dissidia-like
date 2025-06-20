using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prameterDB : MonoBehaviour
{
    [CreateAssetMenu(menuName = "Character_table")]
    public class Character_table : ScriptableObject
    {
        public List<parameters> _characterDB;
    }
    [System.Serializable]
    public class parameters
    {
        public int Character_id;
        public string Character_name;
        public int HP;
        public int MP;
        public int attack;
        public int defense;
        public int speed;
        public Sprite characterIcon;
    }




    [CreateAssetMenu(menuName ="Enemy_table")]
    public class enemyTable : ScriptableObject
    {
        public List<enemy_parameters> story1_enemyDB;
        public List<enemy_parameters> story2_enemyDB;
        public List<enemy_parameters> story3_enemyDB;
    }
    [System.Serializable]
    public class enemy_parameters
    {
        public int Enemy_id;
        public string Enemy_name;
        public int HP;
        public int MP;
        public int attack;
        public int defense;
        public int speed;
        public Sprite EnemyImage;
    }

}

