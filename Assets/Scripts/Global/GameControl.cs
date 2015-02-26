using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    string path;
    string fileName="playerInfo.dat";
    GameData data;
    public Dictionary<String,GameData> gamesData;

	// Use this for initialization
	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/" + fileName;
            gamesData= new Dictionary<string,GameData>();
            control = this;
        }
        else { Destroy(gameObject); }
	}

    void OnLevelWasLoaded()
    {
        Time.timeScale = 1;
    }

    void OnGUI()
    {
        
        if (GUI.Button(new Rect( 10,10,100,100),"Add Value")){
            GameControl.control.gamesData["a"]=new GameData(UnityEngine.Random.Range(0,1000));
        }
        if (gamesData.TryGetValue("a",out data))
        {
            GUI.Label(new Rect(10, 150, 100, 100), "Value:" + gamesData["a"].stars);
        }
        else
        {
            GUI.Label(new Rect(10, 150, 100, 100), "Value:");
        }
    }

    void OnDisable()
    {
        if (path != null) { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData();
        data.gamesData = gamesData;
        bf.Serialize(file, data);
        file.Close();
            }
    }

    void OnEnable()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            gamesData = data.gamesData;
        }
    }
    [Serializable]
    class PlayerData
    {
        public Dictionary<String, GameData> gamesData;
    }

    [Serializable]
    public class GameData
    {
        public int stars;
        public GameData(int stars)
        {
            this.stars = stars;
        }
    }
}
