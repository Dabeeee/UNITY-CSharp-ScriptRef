using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using UnityEngine.UI;
public class DbConfig : MonoBehaviour {
    private string conn, query;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    
    
   
   

    private void Awake()
    {
        
       
    }



	// Use this for initialization
	void Start () {
        LoadDB();
        

        //if (Application.platform != RuntimePlatform.Android)
        //{

        //    conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Testdb.db";//Database Path
        //}
        //else
        //{

        //    //conn = "URI=file:" + Application.persistentDataPath + "/Testdb.db";//Database Path
        //    string p = "Testdb.db";
        //    string filepath = Application.persistentDataPath + "/" + p;
        //    if (!File.Exists(filepath))
        //    {
        //        WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
        //        while (!load.isDone) {}
        //        File.WriteAllBytes(filepath, load.bytes);
        //        conn = "URI=file:" + filepath;//Database Path
        //    }
        //}


      
       // InsertValue("Russel", 2102);//Sample Insert
        //UpdateValue("Alpha", 3);
        //DeleteValue(2);
        
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}

    public void Conn()
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
    public void LoadDB()
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
    void InsertValue(string name, int score)
       
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
    private void UpdateValue(int score,int id)
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

    private void DeleteValue(int id)
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
    private void ReadValue()
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
    public void ReadProgress()
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

                int progress = reader.GetInt32(2);
                int played = reader.GetInt32(4);

                int Progress = progress;
                Debug.Log(Progress);
               



            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
    }
    public void UpdateProgress(int progress, int id)
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
    public void SaveName(string uname,int id)
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
    public void Set(int played, int id)
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
    public void SaveSettings(int quality,float volume,int id)
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

