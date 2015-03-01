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
	[HideInInspector] public int maxHitPoints;
	[HideInInspector] public int playerHitPoints;
	public static GameManager instance = null;
	public float gameDuration;
	public Text hitPointsText;
	public Slider distanceSlider;
	public Image star1;
	public Image star2;
	public Image star3;
	public Sprite star;
	public Sprite emptyStar;

	private float startTime;

	[HideInInspector] public EnemiesManager enemiesManager;
	public GameObject gamesUI;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		enemiesManager = GetComponent <EnemiesManager> ();
		enemiesManager.Init ();
		startTime = Time.time;
		maxHitPoints = 12;
		playerHitPoints = maxHitPoints;
		hitPointsText.text = "" + playerHitPoints;
	}

	// Update is called once per frame
	void Update () {
		enemiesManager.SpawnEnemies ();
		enemiesManager.MoveEnemies ();
		hitPointsText.text = "" + playerHitPoints;
		distanceSlider.value = Mathf.Clamp((((Time.time - startTime) * 100) / gameDuration), 0, 100);
		if (distanceSlider.value >= 100)
			GameOver ();
		if (playerHitPoints < 9) {
			star3.sprite = emptyStar;
			if (playerHitPoints < 4){
				star2.sprite = emptyStar;
			} else {
				star1.sprite = star;
				star2.sprite = star;
			}
		} else {
			star1.sprite = star;
			star2.sprite = star;
			star3.sprite = star;
		}

	}

	public void GameOver (){
		if (playerHitPoints > 9) {
			gamesUI.BroadcastMessage("GameEnded", 3);
		} else if (playerHitPoints > 4) {
			gamesUI.BroadcastMessage("GameEnded", 2);
		} else if (playerHitPoints > 0) {
			gamesUI.BroadcastMessage("GameEnded", 1);
		} else {
			gamesUI.BroadcastMessage("GameEnded", 0);
		}
	}
}
