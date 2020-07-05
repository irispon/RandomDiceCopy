using System;
using System.IO;
using System.Text;
using UnityEngine;

public class WJsonUtill
{
     const string defaltPATH = "/SaveFile"; 


    public static string ObjectToJson(object obj)
    {
        Debug.Log(JsonUtility.ToJson(obj));
        return JsonUtility.ToJson(obj);
    }

    public static T JsonToOject<T>(string jsonData)
    {
        T obj =JsonUtility.FromJson<T>(jsonData);
        return obj;
    }

    public static void SaveJsonFile(string fileName, string jsonData, string createPath = defaltPATH)
    {
        createPath += "/" + "fileName";
        try
        {
            createPath= FileManager.CreatFolder(createPath);
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }
        catch (Exception e)
        {
            Debug.Log("세이브 에러"+e);
        }


    }

   public static T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }

   
   
    
}
