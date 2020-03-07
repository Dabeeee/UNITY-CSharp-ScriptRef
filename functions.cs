using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using UnityEngine.UI;

public class functions : MonoBehaviour {
    private string conn, query;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    public static int Progress;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     public void Conn()//Set Connection
    {


        if (Application.platform != RuntimePlatform.Android)
        {

            conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Testdb.db";//Database Path
        }
        else
        {
            string p = "Testdb.db";
            string filepath = Application.persistentDataPath + "/" + p;
            conn = "URI=file:" + filepath;//Database Path
        }
    }
    public void LoadDB()//load database
    {

        if (Application.platform != RuntimePlatform.Android)
        {

            conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Testdb.db";//Database Path
        }
        else
        {

            //conn = "URI=file:" + Application.persistentDataPath + "/Testdb.db";//Database Path
            string p = "Testdb.db";
            string filepath = Application.persistentDataPath + "/" + p;
            if (!File.Exists(filepath))
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
                while (!load.isDone) { }
                File.WriteAllBytes(filepath, load.bytes);
                conn = "URI=file:" + filepath;//Database Path
            }
        }
    }
    void InsertValue(string name, int score)//Insert value to database
       
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//Open Connection;
            dbcmd = dbconn.CreateCommand();
            query=string.Format("INSERT into Users(Username,Score)values(\"{0}\",\"{1}\")",name,score);
            dbcmd.CommandText=query;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

    }
    private void UpdateValue(int score,int id)//update value to database
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//1.Open connection
            dbcmd = dbconn.CreateCommand();//2.Create Command
            query=string.Format("UPDATE Users set Score=\"{0}\" WHERE Id=\"{1}\"",score,id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();

        }
    }

    private void DeleteValue(int id)//Delete Value to Database
    {
        using (dbconn=new SqliteConnection(conn)){

            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            query = string.Format("DELETE FROM Users WHERE Id=\"{0}\" ", id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void ReadValue()//Read Value to Database
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            query = string.Format("Select * From Users");
            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string boom = reader.GetString(1);
                int score1 = reader.GetInt32(2);

               

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }
    public void ReadProgress()//Read Unlock Level
    {
     
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            query = string.Format("Select * From Users");
            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {

                int progress1 = reader.GetInt32(2);
                int played = reader.GetInt32(4);

                
                
                Debug.Log(progress1);

               



            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }
 
    public void UpdateProgress(int progress, int id)//Update Level if Requirements met
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//1.Open connection
            dbcmd = dbconn.CreateCommand();//2.Create Command
            query = string.Format("UPDATE Users set Progress=\"{0}\" WHERE Id=\"{1}\"", progress, id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            

        }
    }
    public void SaveName(string uname,int id)//Save Basic Username to the database
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//1.Open connection
            dbcmd = dbconn.CreateCommand();//2.Create Command
            query = string.Format("UPDATE Users set Username=\"{0}\" WHERE Id=\"{1}\"", uname, id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();

        }

    }
    public void Set(int played, int id)//Preload Clues functions
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//1.Open connection
            dbcmd = dbconn.CreateCommand();//2.Create Command
            query = string.Format("UPDATE Users set Played=\"{0}\" WHERE Id=\"{1}\"", played, id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();


        }
    }
    public void SaveSettings(int quality,float volume,int id)//Save Settings Configurations
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//1.Open connection
            dbcmd = dbconn.CreateCommand();//2.Create Command
            query = string.Format("UPDATE UserPrefs set Resolution=\"{0}\",Volume1=\"{1}\" WHERE Id=\"{2}\"", quality,volume, id);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();


        }
       


    }




   public  void Register (string name, string password)//Insert value to database
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();//Open Connection;
            dbcmd = dbconn.CreateCommand();
            query = string.Format("INSERT into Users(Username,Password)values(\"{0}\",\"{1}\")", name, password);
            dbcmd.CommandText = query;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

    }



   public void LoginUser(string username, string password)//Read Unlock Level
   {
       int count=0;
       string result = "";
       int id = 0;
       using (dbconn = new SqliteConnection(conn))
       {
           dbconn.Open();
           dbcmd = dbconn.CreateCommand();
           query = string.Format("SELECT * From Users WHERE Username=\"{0}\" AND Password=\"{1}\" ",username,password);
           dbcmd.CommandText = query;
           IDataReader reader = dbcmd.ExecuteReader();
           while (reader.Read())
           {
               count += 1;
               id = reader.GetInt32(0);
            }
           if (count == 1)
           {
               Debug.Log(" Login Succesfully");
               PlayerPrefs.SetString("Username", username);
               PlayerPrefs.SetInt("Id", id);
           }
           else
           {
               result = "Incorrect Username or Password";
               Login.result = result;
           }

           reader.Close();
           reader = null;
           dbcmd.Dispose();
           dbcmd = null;
           dbconn.Close();

       }
   }
   public void AddCart(int id,string product_name, int quantity)//Insert value to database
   {
       using (dbconn = new SqliteConnection(conn))
       {
           dbconn.Open();//Open Connection;
           dbcmd = dbconn.CreateCommand();
           query = string.Format("INSERT into Cart(Userid,product_name,quantity)values(\"{0}\",\"{1}\",\"{2}\")", name, product_name, quantity);
           dbcmd.CommandText = query;
           dbcmd.ExecuteScalar();
           dbconn.Close();
       }

   }


   public void CheckCart(string product_name, int user_id)//Read Unlock Level
   {
       int count = 0;
   
     
       using (dbconn = new SqliteConnection(conn))
       {
           dbconn.Open();
           dbcmd = dbconn.CreateCommand();
           query = string.Format("SELECT Userid,product_name From Cart WHERE Userid=\"{0}\" AND product_name=\"{1}\" ",  user_id,product_name);
           dbcmd.CommandText = query;
           IDataReader reader = dbcmd.ExecuteReader();
           while (reader.Read())
           {
               count += 1;
              
           }
           if (count == 1)

           {
               Debug.Log(count);
               Menu1.Checkif = 0;
           }
           else
           {
               Debug.Log(count);
               Menu1.Checkif = 1;
           }

           reader.Close();
           reader = null;
           dbcmd.Dispose();
           dbcmd = null;
           dbconn.Close();

       }
   }
   public void UpdateCart(int id, string product_name,int quantity)//update value to database
   {
       using (dbconn = new SqliteConnection(conn))
       {
           dbconn.Open();//1.Open connection
           dbcmd = dbconn.CreateCommand();//2.Create Command
           query = string.Format("UPDATE Cart set quantity=\"{0}\" WHERE Userid=\"{1}\" AND product_name=\"{2}\" ", quantity, id,product_name);
           dbcmd.CommandText = query;
           dbcmd.ExecuteScalar();
           dbconn.Close();

       }
   }



   public void ReadCart(int id)//Read Unlock Level
   {
       int count = 0;
       using (dbconn = new SqliteConnection(conn))
       {
           dbconn.Open();
           dbcmd = dbconn.CreateCommand();
           query = string.Format("Select * From Cart WHERE Userid=\"{0}\" ",id);
           dbcmd.CommandText = query;
           IDataReader reader = dbcmd.ExecuteReader();
          
           while (reader.Read())
           {
               
              

              



         





           }
           Cart.num = count;
           reader.Close();
           reader = null;
           dbcmd.Dispose();
           dbcmd = null;
           dbconn.Close();
       }
   }
 
    //public void ReadSettings()
    //{

    //    using (dbconn = new SqliteConnection(conn))
    //    {
    //        dbconn.Open();
    //        dbcmd = dbconn.CreateCommand();
    //        query = string.Format("Select * From UserPrefs");
    //        dbcmd.CommandText = query;
    //        IDataReader reader = dbcmd.ExecuteReader();
    //        while (reader.Read())
    //        {

    //            int quality = reader.GetInt32(1);
    //            float volume = reader.GetFloat(2);
    //            QualitySettings.SetQualityLevel(quality);
    //            Settings.VolSlider.value = volume;


                



                




    //        }
    //        reader.Close();
    //        reader = null;
    //        dbcmd.Dispose();
    //        dbcmd = null;
    //        dbconn.Close();
    //    }
    //}
    //public void Sounds()
    //{
       
    //}
    
}



