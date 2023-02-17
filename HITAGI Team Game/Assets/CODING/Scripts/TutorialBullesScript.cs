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

    public WeaponSwap playerWeaponSwap;
    public Collider2D playerCollider;

    
    public int tutorialStep = 1;
    public bool show3 = false;
    public bool show4 = false;

    public bool tutorialOn = false;
    void Start()
    {
        meshRenderer.sortingOrder = 50;
        playerWeaponSwap = gameObject.transform.parent.GetComponent<WeaponSwap>();
        playerCollider = gameObject.transform.parent.GetComponent<CapsuleCollider2D>();
        if (tutorialOn != true)
        {
            meshRenderer.sortingOrder = -50;
            spriteRenderer.sprite = null;
        }
    }

    private void Update()
    {
        if (tutorialOn)
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
                    BubbleOn("NOW PICK UP\nA WEAPON");
                    if (playerWeaponSwap.weaponSlot1 != 0 || playerWeaponSwap.weaponSlot2 != 0)
                    {
                        StartCoroutine(Wait(1));
                        BubbleOff();
                        tutorialStep = 3;
                    }

                    break;

                case 3:
                    if (show3)
                    {
                        BubbleOn("HOLD [Q] TO\nWORLD WARP");
                        tutorialStep = 4;
                    }

                    break;
                
                case 4:
                    if (show4)
                    {
                        BubbleOff();
                        BubbleOn("MOUSE TO SHOOT");
                        if (Input.GetMouseButtonDown(0))
                            tutorialStep = 5;
                    }
                    break;
                
                case 5:
                        BubbleOff();
                        BubbleOn("[SPACE] TO ROLL");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            BubbleOff();
                            tutorialStep = 6;
                        }

                        break;
            }
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
