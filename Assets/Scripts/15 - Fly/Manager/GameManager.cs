using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
	
	public float xDistance (){return (Mathf.Abs (xMin) + Mathf.Abs (xMax)) / 2;}
	
	public float yDistance (){return (Mathf.Abs (yMin) + Mathf.Abs (yMax)) / 2;}
}

public class GameManager : MonoBehaviour {

	public Boundary boundaries;
	public int playerHitPoints = 10;
	public static GameManager instance = null;
	[HideInInspector] public EnemiesManager enemiesManager;


	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		enemiesManager = GetComponent <EnemiesManager> ();
		enemiesManager.Init ();

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Count: " + enemyManager.GetCount());
		enemiesManager.SpawnEnemies ();
		enemiesManager.MoveEnemies ();
	}

	public void GameOver (){

	}
}
