using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStats(GameStats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamesave.tra";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(stats);

        formatter.Serialize(stream, data);
        Debug.Log("File saved to " + path);
        stream.Close();
    }

    public static GameData LoadStats()
    {
        string path = Application.persistentDataPath + "/gamesave.tra";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in: " + path);
            return null;
        }
    }
}
