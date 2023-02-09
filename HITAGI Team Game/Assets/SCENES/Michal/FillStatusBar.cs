using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public Player_Stats playerHealth;
    public Image fillImage;
    private Slider slider;
        
    void Awake()
	{
	 slider = GetComponent<Slider>();
	}

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
	    {
	 fillImage.enabled = false;
	    }
	if (slider.value > slider.minValue && !fillImage.enabled)
	    {
	 fillImage.enabled = true;
	    }
	float fillValue = playerHealth.health / playerHealth.maxHealth;
	if(fillValue > slider.maxValue / 3)
	{ 	
		fillImage.color = Color.red;
	}
	else if(fillValue > slider.maxValue /3)
	{
		 fillImage.color = Color.red;
	}
	slider.value = fillValue;
	
    }
}