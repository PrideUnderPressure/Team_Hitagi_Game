using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUi : MonoBehaviour
{

    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[0];
    }

    public void GunChange(int x)
    {
        spriteRenderer.sprite = spriteList[x];
    }
}
