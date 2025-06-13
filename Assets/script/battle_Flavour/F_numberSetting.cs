using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_numberSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public int F_Num = 0;
    public int[] num_id_cha = {0,0,0 };
    public ScriptableObject cdb;
    public void character_select(int C_index)
    {
        /*
        ここに{list または array}の'F_Num'番目のデータを,
        キャラクターデータベースの C_index 番目のデータに代入する
        
        by 2025/6/11 の俺
        */
        num_id_cha[F_Num] = cdb;//C_index
    }
}
