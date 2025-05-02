using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private List<CharacterStats> characters = new List<CharacterStats>();

    void Start()
    {
        characters.Add(new CharacterStats { hp = 100f, attack = 50f, defense = 20f, speed = 30f });
        characters.Add(new CharacterStats { hp = 80f, attack = 70f, defense = 10f, speed = 50f });

        Debug.Log("�L����0�̍U����: " + characters[0].attack);
    }
}
