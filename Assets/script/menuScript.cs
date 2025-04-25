using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class menuScript : MonoBehaviour
{
    public Sprite OffSprit;
    public Sprite OnSprit;
    SpriteRenderer SR;
    Vector3 gpos;
    public abstract void select();
    void Start()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        gpos = gameObject.transform.lossyScale;
    }
    public void On()
    {
        if (SR == null) return;
        SR.enabled = OnSprit;
        gameObject.transform.localScale = gpos * 1.5f;
    }
    public void Off()
    {
        if (SR==null) return;
        SR.enabled = OffSprit;
        gameObject.transform.localScale = gpos;
    }
}
