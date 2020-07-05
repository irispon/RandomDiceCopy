using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class DBManager :Singleton<DBManager>
{
    private readonly string URI = "URI=file:";
    private readonly string original_path = Application.streamingAssetsPath + "/WarGameDataBase.db";
    private readonly string copyPath = Application.dataPath +"/WarGameDataBase.db";
     

    public DBManager()
    {


    }

    public void Init()
    {
        File.Copy(original_path, copyPath);
        Debug.Log("DB 초기화");
    }


    public bool DBStateCheck(IDbConnection dbConnection)
    {
        try
        {
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

    public IDataReader DataBaseRead(string query)
    {
        IDbConnection dbConnection = new SqliteConnection(copyPath);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader dataReader = dbCommand.ExecuteReader();

        return dataReader;
        
    }

    public void Close()
    {
        IDbConnection dbConnection = new SqliteConnection(copyPath);
        IDbCommand dbCommand = dbConnection.CreateCommand();
        IDataReader dataReader = dbCommand.ExecuteReader();

        dataReader.Dispose();
        dbCommand.Dispose();
        dbConnection.Close();

    }



}
