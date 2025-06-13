using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDB : MonoBehaviour
{
    [CreateAssetMenu(menuName = "Character_table")]
    public class Character_table : ScriptableObject
    {
        public List<parameters> characterDB;
        
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
}

