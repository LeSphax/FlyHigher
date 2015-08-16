using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{

	public static GameData control;
	
	private SerializableDictionary<String, SceneData> sceneDictionary;
    [HideInInspector]
    public List<string> listPopUpSeen;
    [HideInInspector]
    public List<string> listBuildingsFinished;


    string path;
    string fileName = "playerInfo.dat";
    private SerializableDictionary<String, BuildingData> buildingDictionary;
    string language { get; set; }
    [HideInInspector]
    public float volume;

	public BuildingData[] buildings;



	void Awake ()
	{
		if (control == null) {
			init ();
			control = this;
			initBuildings ();
		} else {
			Destroy (gameObject);
		}
	}

	void init ()
	{
		DontDestroyOnLoad (gameObject);
        listPopUpSeen= new List<string>();
        listBuildingsFinished = new List<string>();
        volume = 1.0f;
		path = Application.persistentDataPath + "/" + fileName;
        sceneDictionary = new SerializableDictionary<string, SceneData>();
        buildingDictionary = new SerializableDictionary<string, BuildingData>();
	}

	public void initBuildings ()
	{
		foreach (BuildingData bd in buildings) {
			buildingDictionary.Add (bd.name, bd);
		}
	}

	public void Reset ()
	{
        sceneDictionary = new SerializableDictionary<string, SceneData>();
        listPopUpSeen = new List<string>();
        listBuildingsFinished = new List<string>();
	}

	public void AddScore (int numberStars)
	{
		string sceneName = Application.loadedLevelName;
		if (!sceneDictionary.ContainsKey (sceneName)) {
			sceneDictionary.Add (sceneName, new SceneData (numberStars));
		} else if (sceneDictionary [sceneName].numberStars < numberStars) {
			sceneDictionary [sceneName] = new SceneData (numberStars);
		}
	}

	public void AddScoreWithLevel (int numberStars, int level)
	{
		string sceneName = Application.loadedLevelName;
		if (!sceneDictionary.ContainsKey (sceneName)) {
			sceneDictionary.Add (sceneName, new SceneData (numberStars, level));
		} else if (sceneDictionary [sceneName].numberStars <= numberStars && sceneDictionary [sceneName].level < level) {
			sceneDictionary [sceneName] = new SceneData (numberStars, level);
		}
	}

	public SceneData GetSceneData (string key)
	{
		if (sceneDictionary.ContainsKey (key)) {
			return sceneDictionary [key];
		} else {
			return new SceneData (0);
		}
	}

	public BuildingData GetBuildingData (string buildingName)
	{
		if (buildingDictionary.ContainsKey (buildingName)) {
			return buildingDictionary [buildingName];
		} else {
			return null;
		}
	}

	public bool AreGamesCompletedInBuilding (string buildingName)
	{
		int nbGames = GetBuildingData (buildingName).nbGames;
		int nbGamesDone = 0;
		foreach (string s in sceneDictionary.Keys) {
			string firstWord = "";
			int index = s.IndexOf (' ');
			if (index != -1) {
				firstWord = s.Substring (0, index);
			}
			if (firstWord == buildingName && sceneDictionary [s].numberStars > 0) {
				nbGamesDone += 1;
			}
		}
		return nbGamesDone == nbGames;
	}

	public int GetBuildingCurrentStars (string buildingName)
	{
		int sum = 0;
		foreach (string s in sceneDictionary.Keys) {
			string firstWord = "";
			int index = s.IndexOf (' ');
			if (index != -1) {
				firstWord = s.Substring (0, index);
			}
			if (firstWord == buildingName) {
				sum += sceneDictionary [s].numberStars;
			}
		}
		return sum;
	}

    void Save()
    {
        if (path != null)
        {
            Saving saving = new SavingWP8();
            FileStream file = File.Create(path);
            PlayerData playerData = new PlayerData();

            playerData.scenesDictionary = sceneDictionary;
            playerData.buildingDictionary = buildingDictionary;
            playerData.language = language;
            playerData.listPopUpSeen = listPopUpSeen;
            playerData.listBuildingsFinished = listBuildingsFinished;
            playerData.volume = volume;

            saving.Save(file, playerData);
            file.Close();
        }
    }

    void Load()
    {
        if (File.Exists(path))
        {
            Saving saving = new SavingWP8();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData playerData = saving.Load(file);

            sceneDictionary = playerData.scenesDictionary;
            listPopUpSeen = playerData.listPopUpSeen;
            listBuildingsFinished = playerData.listBuildingsFinished;
            volume = playerData.volume;
            buildingDictionary = playerData.buildingDictionary;
            language = playerData.language;
        }
    }

	void OnDisable ()
	{
        Save();
	}

	void OnEnable ()
	{
        Load();
	}

	void OnLevelWasLoaded ()
	{
        Save();
		Time.timeScale = 1;
	}


	[Serializable]
	public class PlayerData
	{
        public PlayerData()
        {

        }
        public SerializableDictionary<String, SceneData> scenesDictionary;
        public SerializableDictionary<String, BuildingData> buildingDictionary;
		public string language;
        public List<string> listPopUpSeen; 
        public List<string> listBuildingsFinished;
        public float volume;
	}

	[Serializable]
	public class SceneData
	{
        public SceneData()
        {
        }
		public int numberStars;
		public int level;
		public SceneData (int stars)
		{
			this.numberStars = stars;
			this.level = -1;
		}
		public SceneData (int stars, int level)
		{
			this.numberStars = stars;
			this.level = level;
		}
	}

	[Serializable]
	public class BuildingData
	{
        public BuildingData()
        {
        }
		int maxStars { get; set; }
		public int nbGames;
		public int nbStarsRequired;
		public string name;
		public BuildingData (int nbGames, string name)
		{
			this.maxStars = 3 * nbGames;
			this.nbGames = nbGames;
			this.name = name;
		}
	}
}
