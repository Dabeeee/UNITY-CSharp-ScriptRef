using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Register : MonoBehaviour
{
    public InputField name, password, password2;
    public Text errorhandler;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RegisterUser()
    {
        functions db = GetComponent<functions>();
        db.Conn();
        string validator = "";
        if (name.text == validator && password.text == validator && password2.text == validator)
        {
            errorhandler.text = "All Fields must be answered";

        }
        else
        {
            if (password.text == password2.text)
            {


                db.Register(name.text, password.text);
                Debug.Log("Succesfully registered");
            }
            else
            {
                errorhandler.text = "Password didn't match";
            }
      
        }



    }
}
