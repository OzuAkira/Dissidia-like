using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite imege_on;
    [SerializeField] Sprite imege_off;
    [SerializeField]int i = 0;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        i++;
        if (i >= 10 && i < 20)
        {
            spriteRenderer.sprite = imege_off;
            gameObject.transform.position = new Vector3(0.7f, -0.05f, 0);
        }
        else if (i >= 20)
        {
            spriteRenderer.sprite = imege_on;
            gameObject.transform.position = new Vector3(0.7f, -0.025f, 0);
            i = 0;
        }
    }
}
