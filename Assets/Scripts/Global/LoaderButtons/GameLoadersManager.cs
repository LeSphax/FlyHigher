using UnityEngine;
using System.Collections;

public class GameLoadersManager : MonoBehaviour {

	public GameObject game1Loader;
	public GameObject game2Loader;
	//public GameObject game3Loader;

	private GameData gameData;

	public void Awake(){

		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		//Debug.Log (gameData.GetBuildingData ("Laboratory").nbGames);
		GameLoaderButton game1GLB = game1Loader.GetComponent<GameLoaderButton> ();
		GameLoaderButton game2GLB = game2Loader.GetComponent<GameLoaderButton> ();
		//GameLoaderButton game3GLB = game3Loader.GetComponent<GameLoaderButton> ();
		
		if (gameData.GetSceneData(game1GLB.GetComponent<buttonLoadScene> ().sceneToLoad).numberStars > 0){
			game2GLB.Init(gameData, false);
			if (gameData.GetSceneData(game2GLB.GetComponent<buttonLoadScene> ().sceneToLoad).numberStars > 0){
				//game3GLB.Init(gameData, false);	
			} else {
				//game3GLB.Init(gameData, true);			
			}
		} else {
			game2GLB.Init(gameData, true);
			//game3GLB.Init(gameData, true);
		}
		game1GLB.Init (gameData, false);

	}
}
