using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{

    public static GameData control;
    string path;
    string fileName = "playerInfo.dat";
    public Dictionary<String, SceneData> sceneDictionary;

    // Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/" + fileName;
            sceneDictionary = new Dictionary<string, SceneData>();
            control = this;
        }
        else { Destroy(gameObject); }
    }

    public void AddScore(int numberStars)
    {
        string sceneName = Application.loadedLevelName;
        if (!sceneDictionary.ContainsKey(sceneName) || sceneDictionary[sceneName].numberStars < numberStars)
        {
            sceneDictionary.Add(sceneName, new SceneData(numberStars));
        }

    }

    public SceneData GetSceneData(string sceneName)
    {
        return sceneDictionary[sceneName];
    }

    void OnGUI()
    {
        if (sceneDictionary.ContainsKey("a"))
        {
            GUI.Label(new Rect(10, 150, 100, 100), "Value:" + sceneDictionary["a"].numberStars);
        }
        else
        {
            GUI.Label(new Rect(10, 150, 100, 100), "Value:");
        }
    }

    void OnDisable()
    {
        if (path != null)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            PlayerData playerData = new PlayerData();
            playerData.scenesDictionary = sceneDictionary;
            bf.Serialize(file, playerData);
            file.Close();
        }
    }

    void OnEnable()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            sceneDictionary = playerData.scenesDictionary;
        }
    }
    [Serializable]
    class PlayerData
    {
        public Dictionary<String, SceneData> scenesDictionary;
    }

    [Serializable]
    public class SceneData
    {
        public int numberStars;
        public SceneData(int stars)
        {
            this.numberStars = stars;
        }
    }
}
