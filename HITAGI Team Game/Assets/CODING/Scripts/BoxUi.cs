using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUi : MonoBehaviour
{
    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;
    
    //To be set in the engine - which state should the button begin in.
    public int initial;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[initial];
    }

    public void Activate()
    {
        spriteRenderer.sprite = spriteList[1];
    }

    public void Deactivate()
    {
        spriteRenderer.sprite = spriteList[0];
    }
}
