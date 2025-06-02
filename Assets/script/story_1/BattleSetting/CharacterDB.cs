using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDB : MonoBehaviour
{
    Dictionary<string, Dictionary<string, int>> CDB = new Dictionary<string, Dictionary<string,int>>
    {
        { "User1", new Dictionary<string,int>
            {
                { "hp",0},{ "mp",0},{ "attack",0},{"defense",0},{"speed",0}
            }
        },
        { "User2", new Dictionary<string,int>
            {
                { "hp",0},{ "mp",0},{ "attack",0},{"defense",0},{"speed",0}
            }
        }
    };
}
