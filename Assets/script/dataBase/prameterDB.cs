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
        public Sprite charaImage;

        public abilities ability1;
        public abilities ability2;
        public abilities exAbility;
        public abilities fieldAbility;
        public abilities hyperAbility;
        public abilities ultimateAbility;
    }

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



