using UnityEngine;
using System.Collections;

public class GameLoadersManager : MonoBehaviour {

	public GameObject []gamesLoader;

	private GameData gameData;

	public void Awake(){

		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();

		
	}
    void Start()
    {
        setLocks();
    }

	public void setLocks(){
		gamesLoader [0].GetComponent<GameLoaderButton> ().Init (gameData, false);
		for (int i = 1; i < gamesLoader.Length; i++) {
			GameLoaderButton glb = gamesLoader [i-1].GetComponent<GameLoaderButton> ();
			gamesLoader [i-1].GetComponent<GameLoaderButton> ().Init (gameData, glb.starsNb > 0);
		}
	}
}
