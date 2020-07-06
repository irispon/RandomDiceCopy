using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class DBManager :SingletonObject<DBManager>
{

    private const string dbName="RandomDice";
    public const string original_path= "original_path";
   // public const string copy_Path = "copyPath";

    private string URI = "URI=file:";
    [SerializeField]
    private string serverPath;//서버가 있다 가정
  //  private string copyPath;//복사하는 경로
   // private string copyFilePath;

   // private int init=0;
     


    public override void Init()
    {
        Debug.Log("DB 초기화");
      //  copyPath = "./CopyDB/";
      //  copyFilePath = copyPath + dbName + ".db";
       // Debug.Log(copyPath);
        serverPath = serverPath + "/" + dbName + ".db";
        Debug.Log(serverPath);
        string query = "SELECT Version FROM Certificate";
       IDataReader reader= DataBaseRead(query);
        while (reader.Read())
        {
            Debug.Log(reader.GetInt32(0));
        }
        DontDestroyOnLoad(this);

      
      
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
        Debug.Log("DB테스트");
        //  Close();
        dbConnection.Close();
        dbCommand.Dispose();
        dataReader.Dispose();
        return dataReader;

    }

    public IDataReader DataBaseRead(string query)
    {

        return DataBaseRead(query, serverPath);
        
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
        Close(serverPath);
        
    }



}
