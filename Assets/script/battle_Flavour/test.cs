using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite imege_on;
    [SerializeField] Sprite imege_off;
    [SerializeField] int doFrame = 1;
    int i = 0;
    Vector2 _vector2;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _vector2 = gameObject.transform.position;
    }
    private void Update()
    {
        i++;
        if (i >= doFrame*10 && i < (doFrame*10)*2)
        {
            spriteRenderer.sprite = imege_off;
            gameObject.transform.position = _vector2;
        }
        else if (i >= doFrame*20)
        {
            spriteRenderer.sprite = imege_on;
            gameObject.transform.position = _vector2 + new Vector2(0,0.03f);
            i = 0;
        }
    }
}
