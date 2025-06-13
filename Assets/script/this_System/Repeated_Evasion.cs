using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterDB;

public class Repeated_Evasion : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject[] cells;
    [SerializeField] GameObject[] dumy_cells;
    private menuScript dumyMenu;
    [SerializeField] CharacterDB.Character_table character_Table;
    NewArrow newArrow;
    public Transform _obj;
    //F_numberSetting f_NumberSetting;
    public void Evasion(int[] num_id_cha)
    {
        newArrow = arrow.GetComponent<NewArrow>();
        //f_NumberSetting = gameObject.GetComponent<F_numberSetting>();
        //dumyMenu = dumyObj.GetComponent<menuScript>();
        

        foreach (int x in num_id_cha)
        {
            if(x >= 0)
            {
                //int i = 0;
                foreach(parameters _parameters in character_Table._characterDB)
                {
                    if (_parameters.Character_id == x)
                    {
                        //RectTransform _transform = cells[x].GetComponent<RectTransform>();
                        //GameObject insObj = Instantiate(dumyObj, _transform.position, Quaternion.identity,_obj);
                        //menuScript insMenu = insObj.GetComponent<menuScript>();
                        menuScript d_Menu = dumy_cells[x].GetComponent<menuScript>();
                        newArrow.menus[x] = d_Menu;

                        d_Menu.OnImage = _parameters.characterIcon;
                        d_Menu.OffImage = _parameters.characterIcon;
                        dumy_cells[x].GetComponent<Image>().sprite = _parameters.characterIcon;
                        cells[x].SetActive(false);
                        dumy_cells[x].SetActive(true);
                        break;
                    }
                    //i++;
                }
                for(int i=0;i<cells.Length;i++)
                {
                    if(i != x)
                    {
                        newArrow.menus[i] = cells[i].GetComponent<menuScript>();
                        //dumy_cells[i].SetActive(false);
                    }
                }
            }
        }
    }
}
