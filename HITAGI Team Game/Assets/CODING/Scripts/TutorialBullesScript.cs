using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBullesScript : MonoBehaviour
{
    public Sprite textBubble;
    public SpriteRenderer spriteRenderer;
    public MeshRenderer meshRenderer;
    public TextMesh textMesh;

    public int tutorialStep = 1;
    void Start()
    {
        meshRenderer.sortingOrder = 50;
    }

    private void Update()
    {
        switch (tutorialStep)
        {
            case 1:
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(Wait(1));
                BubbleOff();
                StartCoroutine(Wait(1));
                tutorialStep = 2;
            }
            break; 

                
            case 2:
                BubbleOn("[F] WEAPON PICKUP");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    StartCoroutine(Wait(1));
                    BubbleOff();
                    tutorialStep = 3;
                }
                break;

        }

    }

    private void GetInputs()
    {
        
    }

    public void BubbleOn(string text)
    {
        spriteRenderer.sprite = textBubble;
        textMesh.text = text;
    }

    public void BubbleOff()
    {
        spriteRenderer.sprite = null;
        textMesh.text = null;
    }

    IEnumerator Wait(int x)
    {
        yield return new WaitForSeconds(x);
    }
}
