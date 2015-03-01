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
    public Dictionary<String, BuildingData> buildingDictionary;
    public BuildingData[] buildings;


    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/" + fileName;
            sceneDictionary = new Dictionary<string, SceneData>();
            buildingDictionary = new Dictionary<string, BuildingData>();
            control = this;
            initBuildings();
        }
        else { Destroy(gameObject); }
    }

    public void initBuildings()
    {
        foreach (BuildingData bd in buildings)
        {
            buildingDictionary.Add(bd.name, bd);
        }
    }

    public void Reset()
    {
        sceneDictionary = new Dictionary<string, SceneData>();
    }

    public void AddScore(int numberStars)
    {
        string sceneName = Application.loadedLevelName;
        if (!sceneDictionary.ContainsKey(sceneName))
        {
            sceneDictionary.Add(sceneName, new SceneData(numberStars));
        }
        else if (sceneDictionary[sceneName].numberStars < numberStars)
        {
            sceneDictionary[sceneName] = new SceneData(numberStars);
        }

    }

    public SceneData GetSceneData(string sceneName)
    {
        return sceneDictionary[sceneName];
    }

    public BuildingData GetBuildingData(string buildingName)
    {
        return buildingDictionary[buildingName];
    }

    public int GetBuildingCurrentStars(string buildingName)
    {
        int sum = 0;
        foreach (string s in sceneDictionary.Keys)
        {
            string firstWord = "";
            int index = s.IndexOf(' ');
            if (index != -1)
            {
                firstWord = s.Substring(0, index);
            }
            if (firstWord == buildingName)
            {
                sum += sceneDictionary[s].numberStars;
            }
        }
        return sum;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 250, 100, 50), "Reset"))
        {
            Reset();
        }
        GUI.Label(new Rect(10, 100, 100, 50), "Laboratory:" + GetBuildingCurrentStars("Laboratory"));
        GUI.Label(new Rect(10, 150, 100, 50), "Hangar:" + GetBuildingCurrentStars("Hangar"));
        GUI.Label(new Rect(10, 200, 100, 50), "ControlTower:" + GetBuildingCurrentStars("ControlTower"));
    }

    void OnDisable()
    {
        if (path != null)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            PlayerData playerData = new PlayerData();
            playerData.scenesDictionary = sceneDictionary;
            playerData.buildingDictionary = buildingDictionary;
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
            buildingDictionary = playerData.buildingDictionary;
        }
    }
    [Serializable]
    class PlayerData
    {
        public Dictionary<String, SceneData> scenesDictionary;
        public Dictionary<String, BuildingData> buildingDictionary;
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

    [Serializable]
    public class BuildingData
    {
        public int maxStars;
        public string name;
        public BuildingData(int stars, string name)
        {
            this.maxStars = stars;
            this.name = name;
        }
    }
}
