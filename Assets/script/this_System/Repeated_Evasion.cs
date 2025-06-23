using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.UI;
using static prameterDB;

public class Repeated_Evasion : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject[] cells;
    [SerializeField] GameObject[] dumy_cells;
    //private menuScript dumyMenu;
    [SerializeField] prameterDB.Character_table character_Table;
    NewArrow newArrow;
    public Transform _obj;
    //F_numberSetting f_NumberSetting;
    public void Evasion(int[] num_id_cha)
    {
        newArrow = arrow.GetComponent<NewArrow>();
        //f_NumberSetting = gameObject.GetComponent<F_numberSetting>();
        //dumyMenu = dumyObj.GetComponent<menuScript>();
        List<int> num_id = new List<int>();
        foreach (int x in num_id_cha)
        {
            if(x >= 0)
            {
                num_id.Add(x);               
            }
        }
        for (int i = 0; i < newArrow.menus.Length; i++)
        {
            
            cells[i].SetActive(true);
            newArrow.menus[i] = cells[i].GetComponent<menuScript>();
            dumy_cells[i].SetActive(false);
            
        }
        foreach (int id in num_id)
        {

            newArrow.menus[id] = dumy_cells[id].GetComponent<menuScript>();
            dumy_cells[id].SetActive(true);
            cells[id].SetActive(false);
            
        }
    }
}
