

using System.IO;

public class FileManager 
{

    public static string CreatFolder(string path)
    {

        string folderPath = "./"+path;
        DirectoryInfo di = new DirectoryInfo(folderPath);
        if (di.Exists == false)
        {
            di.Create();
        }

        return folderPath;
    }

    public static string CreateAbsoluteFolder(string path)
    {


        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists == false)
        {
            di.Create();
        }

        return path;
    }


}
