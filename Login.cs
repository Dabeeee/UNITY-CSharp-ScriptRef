using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{



    public InputField name, password;
    public Text errorhandler;
    public static string result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoginUser()
    {
        functions db = GetComponent<functions>();
        db.Conn();
        string validator = "";
        if (name.text == validator && password.text == validator)
        {
            errorhandler.text = "All Fields must be answered";

        }
        else
        {   

            db.LoginUser(name.text, password.text);
            errorhandler.text = result;
        }
    }

}
