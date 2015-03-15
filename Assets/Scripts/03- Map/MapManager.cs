using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MapManager : MonoBehaviour {

	public GameObject laboratoryLoader;
	public GameObject hangarLoader;
	public GameObject controlTowerLoader;
	
	public Image hangarImage;
	public Image controlTowerImage;

	public Sprite hangarLocked;
	public Sprite controlTowerLocked;
	public Sprite hangarUnlocked;
	public Sprite controlTowerUnlocked;

	private SceneLoaderButton laboSLB;
	private SceneLoaderButton hangarSLB;
	private SceneLoaderButton controlTowerSLB;

	private GameData gameData;

	// Use this for initialization
	void Awake () {
		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		laboSLB = laboratoryLoader.GetComponent<SceneLoaderButton> ();
		hangarSLB = hangarLoader.GetComponent<SceneLoaderButton> ();
		controlTowerSLB = controlTowerLoader.GetComponent<SceneLoaderButton> ();
		try {
		if (gameData.AreGamesCompletedInBuilding("Laboratory")){
			hangarSLB.Init(gameData, false);
			if (gameData.AreGamesCompletedInBuilding("Hangar")){
				controlTowerSLB.Init(gameData, false);	
			} else {
				controlTowerSLB.Init(gameData, true);			
			}
		} else {
			hangarSLB.Init(gameData, true);
			controlTowerSLB.Init(gameData, true);
		}
		laboSLB.Init (gameData, false);
		} catch (NullReferenceException nre){
			laboSLB.Init (gameData, false);
			hangarSLB.Init(gameData, true);
			controlTowerSLB.Init(gameData, true);
		}
	}
}
