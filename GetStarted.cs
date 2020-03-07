using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStarted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string scenename)
    {
        string username = PlayerPrefs.GetString("Username");
        if (username == "")
        {
            Application.LoadLevel("login");
            Debug.Log(username);
           
        }
        else
        {
            Application.LoadLevel(scenename);
            Debug.Log(username);
        }

    }
}
