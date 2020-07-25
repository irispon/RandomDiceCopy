using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DBManager :SingletonObject<DBManager>
{
    public static string PlayerID= "Player";
    private const string dbName="RandomDice";
    public const string original_path= "original_path";
   // public const string copy_Path = "copyPath";

    private string URI = "URI=file:";
    [SerializeField]
    private string localPath;
    [SerializeField]
    bool isApp;
    public StringBuilder stringBuilder;
    private bool check= false;



    public override void Init()
    {



       stringBuilder = new StringBuilder();
       Debug.Log("DB 초기화");

        string filepath = string.Empty;
        if(Application.platform == RuntimePlatform.Android)
        {
            stringBuilder.Clear();
            filepath = stringBuilder.Append(Application.persistentDataPath).Append("/RandomDice.db").ToString();
          //  string serverPath = stringBuilder.Append("jar:file://").Append(Application.dataPath).Append("!/assets/RandomDice.db").ToString();
       //     Debug.Log("어플리케이션"+filepath +" " + serverPath);

            stringBuilder.Clear();
                if (!File.Exists(filepath))
                {
                //  File.Delete(filepath);
                UnityWebRequest unityWebRequest = UnityWebRequest.Get(stringBuilder.Append("jar:file://").Append(Application.dataPath).Append("!/assets/RandomDice.db").ToString());
                Debug.Log(unityWebRequest.downloadedBytes.ToString());
                while (unityWebRequest.SendWebRequest().isDone) ;
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
              }


   
        }
        else
        {
            Debug.Log("PC 플랫폼");
            filepath = Application.dataPath + "/RandomDice.db";
            if (!File.Exists(filepath)|| !Certificate(filepath, Application.streamingAssetsPath + "/RandomDice.db"))
            {
                Debug.Log(filepath);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                File.Copy(Application.streamingAssetsPath + "/RandomDice.db", filepath);
                
            }
        }


        localPath = filepath;


        
     //  serverPath = stringBuilder.Append(serverPath).Append("/").Append(dbName).Append(".db").ToString();

      
       Debug.Log(localPath);
        


        DontDestroyOnLoad(this);

      
      
    }

    bool Certificate(string localPath,string serverPath)
    {
        string query = "SELECT Version FROM Certificate";
        IDataReader local = DataBaseRead(query, localPath);
        IDataReader server = DataBaseRead(query, serverPath);

        string localVersion="local";
        string serverVersion="server";
        while (local.Read())
        {
            localVersion = local.GetString(0);
           
        }
        while (server.Read())
        {

            serverVersion = server.GetString(0);
        }

        Debug.Log(localVersion+"   "+serverVersion);

        return localVersion.Equals(serverVersion);


    }
    /*
     public void Create()
    {

        try
        {

            FileManager.CreatFolder(copyPath);
            DBStateCheck(serverPath);
            if (File.Exists(copyFilePath))
            {
            
                DBStateCheck(copyFilePath);
                string query = "SELECT Version FROM Certificate";
 
                float serVison=0;
                float copyVison=1;
                IDataReader server = DataBaseRead(query, serverPath);
          
                IDataReader copy =DataBaseRead(query, copyFilePath);
                while (server.Read())
                {
                
                    serVison = server.GetFloat(0);
                    Debug.Log("서버 버전 체크"+ serVison);
                }
                while (copy.Read())
                {
                    
                    copyVison = copy.GetFloat(0);
                    Debug.Log("카피 버전 체크"+ copyVison);
                }

                if (!serVison.Equals(copyVison))
                {
                    Debug.Log("버전이 다릅니다. 교체작업을 시작합니다.");
                    Close(copyFilePath);
                    File.Delete(copyFilePath);
                    File.Copy(serverPath, copyFilePath);
                }


            }
            else
            {
                File.Copy(serverPath, copyFilePath);
            }


        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        Debug.Log("카피");
    }
    */

    public bool DBStateCheck(string path)
    {
        path = URI + path;
        try
        {
            IDbConnection dbConnection = new SqliteConnection(path);
            if (dbConnection.State == ConnectionState.Open)
            {
              
                return true;
            }
        }
        catch (Exception e)
        {
            Debug.Log("DB연결 에러 "+e);
        }

        return false;
    }

    public IDataReader DataBaseRead(string query,string path)
    {
        path = URI + path;
        IDbConnection dbConnection = new SqliteConnection(path);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader dataReader = dbCommand.ExecuteReader();
       
        //  Close();
        dbConnection.Close();
        dbCommand.Dispose();
        dataReader.Dispose();
        return dataReader;

    }

    public IDataReader DataBaseRead(string query)
    {

        return DataBaseRead(query, localPath);
        
    }


    public bool VersionCheck()
    {


        return true;
    }
    public void Close(string path)
    {
        try
        {

        path = URI + path;
        IDbConnection dbConnection = new SqliteConnection(path);
        IDbCommand dbCommand = dbConnection.CreateCommand();
        
            try
            {
                IDataReader dataReader = dbCommand.ExecuteReader();
                dataReader.Dispose();
            }
            catch(Exception e)
            {
               //Debug.Log(e);
            }
      
  

        dbCommand.Dispose();
        dbConnection.Close();
        }
        catch (Exception e)
        {
            Debug.Log("DB종료 에러"+e);
        }
    }

    public void OnApplicationQuit()
    {

        GC.Collect();
        Close(localPath);
        
    }



}
