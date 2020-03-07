using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    // Start is called before the first frame update
    public static int num;
    int i;
    public Text[] mytext;
    void Start()
    {
        functions db = GetComponent<functions>();
        db.Conn();
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
