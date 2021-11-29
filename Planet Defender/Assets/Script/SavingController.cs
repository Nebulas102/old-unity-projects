using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingController : MonoBehaviour
{
    public static void WriteDataToFile(string fileName, string data)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        Debug.Log("AssetPath:" + path);
        File.WriteAllText(path, data);
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    public static bool FileExists(string fileName)
    {
        return File.Exists(Application.persistentDataPath + "/" + fileName + ".json");
    }

    public static string LoadDataFromFile(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        return File.ReadAllText(path);

        //ScoreSystem loadedData = JsonUtility.FromJson<ScoreSystem>(dataAsJson);
    }
}
