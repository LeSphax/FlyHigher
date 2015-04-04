using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
	
	public float xDistance (){return (Mathf.Abs (xMin) + Mathf.Abs (xMax)) / 2;}
	
	public float yDistance (){return (Mathf.Abs (yMin) + Mathf.Abs (yMax)) / 2;}
}

public class GameManager : MonoBehaviour {

	public Boundary boundaries;
	[HideInInspector] public const int maxHitPoints = 6;
	[HideInInspector] public int playerHitPoints;
	public static GameManager instance = null;
	public float gameDuration;
	public Text hitPointsText;
	public Slider distanceSlider;

	public GameObject endLine;

	private float startTime;

	[HideInInspector] public EnemiesManager enemiesManager;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		enemiesManager = GetComponent <EnemiesManager> ();
		enemiesManager.Init ();
		startTime = Time.time;
		playerHitPoints = maxHitPoints;
		hitPointsText.text = "" + playerHitPoints;
	}

	// Update is called once per frame
	void Update () {
		if (distanceSlider.value < 100){
			enemiesManager.SpawnEnemies ();
			enemiesManager.MoveEnemies ();
			distanceSlider.value = Mathf.Clamp((((Time.time - startTime) * 100) / gameDuration), 0, 100);
			if ((Time.time - startTime) > (gameDuration - 6))
				endLine.GetComponent<EndLine> ().MoveEndLine ();
			if (distanceSlider.value >= 100){
				GameOver ();
			}
		}

	}

	public void PlayerHit(){
		playerHitPoints --;
		hitPointsText.text = "" + playerHitPoints;
		if (playerHitPoints <= 0){
			GameOver ();
		}
	}

	public void GameOver (){
		distanceSlider.gameObject.SetActive (false);
        GameObject gamesUI = GameObject.FindWithTag("GamesUI");
		int starNb;
		if (playerHitPoints >= 6) {
			starNb = 3;
		} else if (playerHitPoints >= 4) {
			starNb = 2;
		} else if (playerHitPoints > 0) {
			starNb = 1;
		} else {
			starNb = 0;
		}
		enemiesManager.DestroyAll ();
		gamesUI.BroadcastMessage("GameEnded", starNb);
	}
}
