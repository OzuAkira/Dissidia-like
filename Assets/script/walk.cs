using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] int doFrame = 1;

    public Sprite imege_on;
    public Sprite imege_off;
    public bool _walk = false;

    int i = 0;
    Vector2 _vector2;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _vector2 = gameObject.transform.position;
    }
    private void Update()
    {
        if (_walk)
        {
            i++;
            if (i >= doFrame * 10 && i < (doFrame * 10) * 2)
            {
                spriteRenderer.sprite = imege_off;
                gameObject.transform.position = _vector2;
            }
            else if (i >= doFrame * 20)
            {
                spriteRenderer.sprite = imege_on;
                gameObject.transform.position = _vector2 + new Vector2(0, 0.03f);
                i = 0;
            }
        }
    }
}
