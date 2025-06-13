using UnityEngine;
using UnityEngine.UI;
using static CharacterDB;


public class test_db : MonoBehaviour
{
    public CharacterDB.Character_table character_Table;
    int[] Sequential = {0,0,0};
    public int favour_number;
    private void Start()
    {
        Image image = gameObject.GetComponent<Image>();
        Debug.Log("ccc");
        foreach(parameters _parameters in character_Table._characterDB)
        {
            if (_parameters.Character_id == favour_number)
            {
                Sprite target = _parameters.characterIcon;
                image.sprite = target;
            }
                
        }
        
        //image.sprite = target.characterIcon;

    }
    
}
