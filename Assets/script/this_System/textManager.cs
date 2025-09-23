using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour//textとは書いてあるが、データは画像で行く予定
{
    public GameObject text_and_frame;
    public Image image;
    [SerializeField] List<Sprite> imagesArray;
    private void Start()
    {
        image = text_and_frame.GetComponent<Image>();
    }
    public void putText(string name)
    {
        switch (name)
        {
            case "とびつく":
                image.sprite = imagesArray[0];
                break;

        }
    }
}
