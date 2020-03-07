using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
  
    private float fillAmount;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image Content;
    [SerializeField]
    private Text Valuetext;
     
    

    public float  MaxValue { get; set; }
    public float Value
    {
        set
        {
            string[] tmp = Valuetext.text.Split(':');
            string format = value.ToString("0");
            Valuetext.text = tmp[0] + ":" + format;
            fillAmount=Map(value,0,MaxValue,0,1);
          
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        HandleBar();    
	}
    private void HandleBar()
    {
        if (fillAmount != Content.fillAmount)
        {
            Content.fillAmount = Mathf.Lerp(Content.fillAmount,fillAmount,Time.deltaTime*lerpSpeed);
        }
        
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
   
}

