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
	public int maxHitPoints = 10;
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
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Count: " + enemyManager.GetCount());
		enemiesManager.SpawnEnemies ();
		enemiesManager.MoveEnemies ();
		hitPointsText.text = "" + playerHitPoints;
		distanceSlider.value = Mathf.Clamp((((Time.time - startTime) * 100) / gameDuration), 0, 100);
		if (distanceSlider.value >= 100)
			GameOver (true);
		if (((float)playerHitPoints / (float)maxHitPoints) < .8f) {
			star3.sprite = emptyStar;
			if (((float)playerHitPoints / (float)maxHitPoints) < .5f){
				star2.sprite = emptyStar;
				if (((float)playerHitPoints / (float)maxHitPoints) < .2f){
					star1.sprite = emptyStar;
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

	public void GameOver (bool win){
		if (win) {
			//TODO wining process;
		} else {
			//TODO loosing process;
		}
	}
}
