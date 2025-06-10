using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class menuScript : MonoBehaviour
{
    public Sprite OffImage;
    public Sprite OnImage;
    Image _image;
    
    Vector3 gpos;
    public abstract void select();
    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        gpos = gameObject.transform.lossyScale;
    }
    public void On()
    {
        if (_image == null) return;
        _image.sprite = OnImage;
    
        //gameObject.transform.localScale = gpos * 1.5f;
    }
    public void Off()
    {
        if (_image ==null) return;
        _image.sprite = OffImage;
        //gameObject.transform.localScale = gpos;
    }
}
