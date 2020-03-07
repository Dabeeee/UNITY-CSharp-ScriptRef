using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class Menu1 : MonoBehaviour


{

    public InputField product1, product2, product3;
    string text;
    public string ProductName,ProductName1,ProductName2;
    public static int Checkif;


    // Start is called before the first frame update
    
    void Start()
    {
     
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cart()
    {
        functions db = GetComponent<functions>();
        db.Conn();
        string validator = "";
     
        int session_id = PlayerPrefs.GetInt("Id");
      
        int quantity=int.Parse(product1.text);
       db.CheckCart(ProductName,session_id);
       Debug.Log(Checkif);
        if(Checkif==0)
        {
         //update
            db.UpdateCart(session_id,ProductName,quantity);

        }
        else
        {
        //insert
            
            db.AddCart(session_id, ProductName, quantity);
            Debug.Log("Product Added to Cart");

        }

    }

    public void Cart1()
    {
        functions db = GetComponent<functions>();
        db.Conn();
        string validator = "";

        int session_id = PlayerPrefs.GetInt("Id");

        int quantity = int.Parse(product2.text);
        db.CheckCart(ProductName1, session_id);
        Debug.Log(Checkif);
        if (Checkif == 0)
        {
            //update
            db.UpdateCart(session_id, ProductName1, quantity);

        }
        else
        {
            //insert

            db.AddCart(session_id, ProductName1, quantity);
            Debug.Log("Product Added to Cart");

        }

    }


    public void Cart2()
    {
        functions db = GetComponent<functions>();
        db.Conn();
        string validator = "";

        int session_id = PlayerPrefs.GetInt("Id");

        int quantity = int.Parse(product3.text);
        db.CheckCart(ProductName2, session_id);
        Debug.Log(Checkif);
        if (Checkif == 0)
        {
            //update
            db.UpdateCart(session_id, ProductName2, quantity);

        }
        else
        {
            //insert

            db.AddCart(session_id, ProductName2, quantity);
            Debug.Log("Product Added to Cart");

        }

    }
}
