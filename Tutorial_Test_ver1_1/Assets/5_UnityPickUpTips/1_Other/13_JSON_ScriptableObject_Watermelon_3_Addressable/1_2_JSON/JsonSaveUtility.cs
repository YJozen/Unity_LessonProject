using System.IO;
using UnityEngine;

public static class JsonSaveUtility
{
    public static string SaveFilePath = $"{Application.persistentDataPath}/SaveData.json"; 

    public static void Save<T>(T data) where T : class
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SaveFilePath, json);
        Debug.Log(SaveFilePath);
    }

    public static T Load<T>()where T : class
    {
        if (!File.Exists(SaveFilePath))
        {
            string json = File.ReadAllText(SaveFilePath);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            Debug.Log("ファイルがありません。");
            return null;
        }

    }
}