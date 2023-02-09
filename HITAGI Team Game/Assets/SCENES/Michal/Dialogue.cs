using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
	StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
	{
	 if(textComponent.text == lines[index])
	{
	 NextLine();
	}
	else
	{
	StopAllCoroutines();
	textComponent.text = lines[index];
	}
	}
    }

    void StartDialogue()
    {
	index = 1;
	StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
	{
	foreach (char c in lines[index].ToCharArray())
	{
	 textComponent.text += c;
	 yield return new WaitForSeconds(textSpeed);
	 if (index == 6)
	 {
		 StartCoroutine(WaitToSwitch());
	 }
	}
   }
void NextLine()
	{
	if(index < lines.Length -1)
	{
	 index++;
	 textComponent.text = string.Empty;
	 StartCoroutine(TypeLine());
	}
	else
	{
	gameObject.SetActive(false);
	}
}

IEnumerator WaitToSwitch()
{
	yield return new WaitForSeconds(3);
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
}

