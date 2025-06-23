using UnityEditor;
using UnityEngine;

public class SaveDB : MonoBehaviour
{
    [SerializeField]
    ScriptableObject Table;

    void Start()
    {
        EditorUtility.SetDirty(Table);
        AssetDatabase.SaveAssets();
    }
}