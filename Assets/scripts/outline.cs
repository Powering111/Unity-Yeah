using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline : MonoBehaviour
{

    public Sprite normal, selected;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        OnDisable();
    }

    public void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        UpdateOutline(true);
    }

    public void OnDisable()
    {
        UpdateOutline(false);
    }


    void UpdateOutline(bool outline)
    {
        if (outline)
        {
            spriteRenderer.sprite = selected;
        }
        else
        {
            spriteRenderer.sprite = normal;
        }
    }
}
