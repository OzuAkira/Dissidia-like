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
        ������{list �܂��� array}��'F_Num'�Ԗڂ̃f�[�^��,
        �L�����N�^�[�f�[�^�x�[�X�� C_index �Ԗڂ̃f�[�^�ɑ������
        
        by 2025/6/11 �̉�
        */
        num_id_cha[F_Num] = cdb;//C_index
    }
}
