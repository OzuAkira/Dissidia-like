using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class toraion : MonoBehaviour
{
    take_status enemy_Status , character_Status;
    float attack;
    private void Start()
    {
        enemy_Status = gameObject.GetComponent<take_status>();
        attack = enemy_Status.now_attack;
    }
    public void _action(int num , GameObject[] targets)//難易度の分岐
    {
        switch (num)
        {
            case 0:
                
              



            break;

            case 1:
                //---
            break;

        }
    }
    void fastKill(GameObject[] _targets)
    {
        //int[] killFlag = new int[3];
        List<int> killFlag = new List<int>();
        Debug.Log("kill_F = "+killFlag);
        int i = 0;
        
        foreach (GameObject chara in _targets)
        {
            character_Status = chara.GetComponent<take_status>();
            float chara_defense = character_Status.now_defense;
            if(chara_defense - attack >= character_Status.now_HP)killFlag.Add(i);
            i++;
        }
        switch(killFlag.Sum())
        {
            case 1:
                character_Status = _targets[killFlag[0]].GetComponent<take_status>();

                //アニメーションを入れる予定（多分コルーチンを呼ぶ）

                character_Status.now_HP -= (character_Status.now_defense - attack * 1.2f);//ダメージ処理
                break;
                
        }
        
    }
}
