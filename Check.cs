 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
public class Check : MonoBehaviour
{
    public string scene1, scene2;
    private string conn, query;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    public int Played;
    public int Coord;
    void Start()
    {
        Conn();

        ReadProgress(Coord);
        Debug.Log(Played);
        

        if (Played == 1)
        {
            Application.LoadLevel(scene1);
        }
        else if (Played == 2)
        {
            Application.LoadLevel(scene2);
        }
    }
    public void ReadProgress(int a)
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
                int played = reader.GetInt32(a);

                int Progress = progress;
                Played = played;
               




            }
        }
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
}
