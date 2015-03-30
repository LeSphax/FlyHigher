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
		maxHitPoints = 12;
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
		if (playerHitPoints < 9) {
			star3.sprite = emptyStar;
			if (playerHitPoints < 4){
				star2.sprite = emptyStar;
				if (playerHitPoints <= 0){
					star1.sprite = emptyStar;
					GameOver ();
				} else {
					star1.sprite = star;
				}
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
        GameObject gamesUI = GameObject.FindWithTag("GamesUI");
		int starNb;
		if (playerHitPoints >= 9) {
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
