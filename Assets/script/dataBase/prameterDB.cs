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
        public int[] element = new int[7];
        public Sprite characterIcon;
        public Sprite image;
    }




    [CreateAssetMenu(menuName ="Enemy_table")]
    public class enemyTable : ScriptableObject
    {
        public List<enemy_parameters> _enemyDB;
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
        public int[] element = new int[7];
       // public abilities[] abilities;
        public Sprite EnemyImage;
    }

    [CreateAssetMenu(menuName = "abilityList")]
    public class abilityList : ScriptableObject
    {
        public List<playerAbility> playerAbilities;
    }
    [System.Serializable]
    public  class playerAbility
    {
        public int character_id;
        public string character_name;

        public GameObject abilities;

    }
    /*
    [System.Serializable]
    public class ability_infomation
    {
        public string name;
        public int remainder;
        //public string element;
        public string weapon_type;//int‚Å‚à—Ç‚¢
        public abilities ability;
    }
    */

    [CreateAssetMenu(menuName = "buffList")]
    public class buffList : ScriptableObject
    {
        public List<playerBuff> playerBuff;
    }
    [System.Serializable]
    public class playerBuff
    {
        //public string buff_name;
        public Image buff_icon;
    }

}



