using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private Stats Health;
    

   
    private float Increase=0.1f;

   

    private void Awake()
    {
        Health.Initialize();
         Health.CurrentVal = PlayerPrefs.GetFloat("Energ");
    }


    // Update is called once per frame
    void Update()
    {
        Refill();
       
        if (Input.GetKeyDown(KeyCode.A))
        {
            Health.CurrentVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Health.CurrentVal -= 10;
        }
       
    }
    private void Refill()
    {
       
        Health.CurrentVal += Increase * Time.deltaTime;
        PlayerPrefs.SetFloat("Energ", Health.CurrentVal);

       
        
    }
    
}
