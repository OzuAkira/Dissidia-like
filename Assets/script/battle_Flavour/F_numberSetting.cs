using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_numberSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public int F_Num = 0;
    public int[] num_id_cha = {-999, -998, -997 };
    public GameObject number_select,characterList;
    public GameObject[] fst;
    private Flavour_setting fs;
    //public CharacterDB.Character_table cdb;
    public IEnumerator character_select(int C_index)
{       
        num_id_cha[F_Num] = C_index;
        characterList.SetActive(false);
        number_select.SetActive(true);

        /*
        Debug.Log(num_id_cha[0]);
        Debug.Log(num_id_cha[1]);
        Debug.Log(num_id_cha[2]);
        */

        foreach (GameObject objects in fst)
        {
            fs = objects.GetComponent<Flavour_setting>();
            //Debug.Log("foreach");
            fs.updateWindow(num_id_cha);
            
        }
        Repeated_Evasion re = gameObject.GetComponent<Repeated_Evasion>();
        re.Evasion(num_id_cha);
        yield return null;
    }
}
