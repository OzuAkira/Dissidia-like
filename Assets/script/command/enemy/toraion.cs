using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class toraion : MonoBehaviour
{
    take_status enemy_Status , character_Status;
    [SerializeField] GameObject GM;
    float attack;
    textManager textManager;
    private void Start()
    {
        enemy_Status = gameObject.GetComponent<take_status>();
        attack = enemy_Status.now_attack;
        textManager = GM.GetComponent<textManager>();

    }
    public void _action(int num , GameObject[] targets)//難易度の分岐
    {
        switch (num)
        {
            case 0:

                fastKill(targets);



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
            if(chara_defense - attack >= character_Status.now_HP)killFlag.Add(i);//一撃で倒せる奴らを探す
            i++;
        }
        switch(killFlag.Sum())
        {
            case 1:
                character_Status = _targets[killFlag[0]].GetComponent<take_status>();
                //アニメーションを入れる予定（多分コルーチンを呼ぶ）
                //ダメージ処理も混ぜる



                AbilityAnime(_targets[killFlag[0]] , "とびつく");


                float damge = character_Status.now_HP - (character_Status.now_defense - attack * 1.2f);//ダメージ予測
                StartCoroutine(takeDamge());
                break;
                
        }
        IEnumerator takeDamge()//アニメーションを再生
        {

            yield return new WaitForSeconds(1);
            Debug.Log("アニメーションを再生するよ！");

        }
    }
    IEnumerator AbilityAnime(GameObject target , string name)
    {
        target.transform.position += new Vector3(2,0,0);
        textManager.putText(name);
        yield return new WaitForSeconds(1.5f);
        target.transform.position -= new Vector3(2, 0, 0);
    }
    
}
