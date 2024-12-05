using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(string sceneName, Vector3 playerPosition)
    {
        SaveData data = new SaveData();
        data.sceneName = sceneName;
        data.playerPosition = playerPosition;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.LogError("Save file not found!");
            return null;
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string sceneName;
    public Vector3 playerPosition;
}
