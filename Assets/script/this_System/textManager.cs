using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour//textとは書いてあるが、データは画像で行く予定
{
    public GameObject text_and_frame , damgeObj;
    public Image image;
    [SerializeField] List<Sprite> imagesArray;
    private void Start()
    {
        image = text_and_frame.GetComponent<Image>();
        text_and_frame.SetActive(false);
    }
    public IEnumerator putText(string name)
    {
        switch (name)
        {
            case "とびつく":

                image.sprite = imagesArray[0];
                text_and_frame.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                text_and_frame.SetActive(false);
                break;

        }
    }
    public IEnumerator damage()
    {
        yield return null;
    }
}
