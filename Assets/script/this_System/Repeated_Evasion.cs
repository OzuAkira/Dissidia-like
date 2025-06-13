using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterDB;

public class Repeated_Evasion : MonoBehaviour
{
    [SerializeField] GameObject arrow,dumyObj;
    [SerializeField] GameObject[] cells;
    private menuScript dumyMenu;
    [SerializeField] CharacterDB.Character_table character_Table;
    NewArrow newArrow;
    //F_numberSetting f_NumberSetting;
    public void Evasion(int[] num_id_cha)
    {
        newArrow = arrow.GetComponent<NewArrow>();
        //f_NumberSetting = gameObject.GetComponent<F_numberSetting>();
        dumyMenu = dumyObj.GetComponent<menuScript>();

        foreach (int x in num_id_cha)
        {
            if(x >= 0)
            {
                foreach(parameters _parameters in character_Table._characterDB)
                {
                    if (_parameters.Character_id == x)
                    {
                        dumyMenu.OffImage = _parameters.characterIcon;
                        dumyMenu.OnImage = _parameters.characterIcon;
                        newArrow.menus[x] = dumyMenu;
                        RectTransform _transform = cells[x].GetComponent<RectTransform>();
                        Instantiate(dumyObj, _transform.position,Quaternion.identity);
                        cells[x].SetActive(false);
                        break;
                    }
                    else Debug.Log("id_over");
                }
                
            }
        }
    }
}
