using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public Text Score;
  

	// Use this for initialization
	void Start () {
        Score.text = ScoringSys.final.ToString();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
