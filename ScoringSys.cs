using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoringSys : MonoBehaviour {
    public int time;
    public Text timer;
    public static int  final=0;
    public static int test;
  
    private int index = 1;
   
    //public int Bonus1;
    //public int Bonus2;
    //public int Bonus3;
    //public int Bonus4;
   





	// Use this for initialization
	void Start () {
        TimerStart();
        
        



    }
    void Update()
    {
        
       
        GameOver();
       
       
    }

    // Update is called once per frame
    //void Update () {
    //    IncrementTime();
    //    timer.text = time.ToString( );

    //}
    public void TimerStart()
    {
       
        InvokeRepeating("IncrementTime", 1, 1);

    }
    public void TimerStop()
    {
        PlayerPrefs.SetInt("time", time);
        CancelInvoke();
        
       
    }
    public void Resume()
    {
       time = PlayerPrefs.GetInt("time");
        TimerStart();
    }
    public void IncrementTime()
    {

        time -=1;
        timer.text =time.ToString();
    }
    public void Score()
    {
        
            //Output.text = "Score:" + time;
        
    }
    public void GameOver()
    {
        if (time < 0)
        {
            Application.LoadLevel("Gameover");
        }
    }

    public void FinalScore()
    {


      

       
      
    }
    
}
