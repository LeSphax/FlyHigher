using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockSpawnControllerScript : MonoBehaviour
{

		[System.Serializable]
		public class BoxAndItem
		{
				public GameObject box;
				public GameObject item;
	
		}

		public List <BoxAndItem> boxItems; // Association box et items .
		public Vector3[] spawnPositionsItems;
		public List<Vector3> spawnPositionsBox ;
		public GameObject carpet;
		public GameObject gamesUI;



		public int itemCount;
		public float spawnWait;
		public float startWait;
		public float waveWait;
		public int nbWavesMax;


		public static int nbItemMissed = 0;

		private List<GameObject> itemSpawnnable = new List<GameObject> (); // Liste des différents types d'items qui peuvent actuellement apparaitre

		private int currentWave;
		private float speed;



		// Use this for initialization
		void Start ()
		{
				nbItemMissed = 0;
				currentWave = 0;
				speed = 2f;
				SpawnCarpet ();
				SpawnBox ();
				SpawnBox ();
				StartCoroutine (SpawnWaves ());
		}


		IEnumerator SpawnWaves ()
		{
				
				yield return new WaitForSeconds (startWait);
				while (currentWave < nbWavesMax) {
						for (int i = 0; i < itemCount; i++) {
								Instantiate (itemSpawnnable [Random.Range (0, itemSpawnnable.Count)], spawnPositionsItems [Random.Range (0, spawnPositionsItems.Length)], Quaternion.identity);
								yield return new WaitForSeconds (spawnWait);
						}
	
						yield return new WaitForSeconds (waveWait);
						

						spawnWait -= 0.5f;
						//waveWait -= 0.5f;
						currentWave++;
						if (currentWave == 1) {
								speed += 1f;
								SpawnBox ();
						}

						if (currentWave == 2) {
								SpawnBox ();
								speed += 2f;
						}

						foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) {
								if (obj.layer == LayerMask.NameToLayer ("Pickable")) {
										obj.GetComponent<StockInteractionPlayer> ().SetSpeed (speed);
								}
						}
				}
				bool notEnd = true;
				while (notEnd) {
						yield return new WaitForSeconds (1);
						notEnd = false;
						foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) {
								if (obj.layer == LayerMask.NameToLayer ("Pickable")) {
										notEnd = true;
								}
						}					
				}
				EndGame ();
	


		}

		public float GetSpeed ()
		{
				return this.speed;
		}


		private void SpawnBox ()
		{
				Vector3 posRand = spawnPositionsBox [Random.Range (0, spawnPositionsBox.Count)];
				BoxAndItem boxItemsToSpawn = boxItems [Random.Range (0, boxItems.Count)];

				Instantiate (boxItemsToSpawn.box, posRand, Quaternion.identity);
				itemSpawnnable.Add (boxItemsToSpawn.item);

				// On enleve la position ou la box a spawn ainsi que la box qui a spawn pour pas avoir 2 fois la meme
				spawnPositionsBox.Remove (posRand);
				boxItems.Remove (boxItemsToSpawn);
		}

		private void SpawnCarpet ()
		{
				for (int i =0; i < spawnPositionsItems.Length; i++) {
						Vector3 offset = new Vector3 (0, -0.5f, 0) - spawnPositionsItems [i];
						Instantiate (carpet, spawnPositionsItems [i] + offset, Quaternion.identity);
				}
		}

		private void EndGame ()
		{
				gamesUI.BroadcastMessage ("GameEnded", calculNumberStar ());
		}

		private int calculNumberStar ()
		{
				if (nbItemMissed < 3) {
						return 3;
				} else if (nbItemMissed < 11) {
						return 2;
				} else if (nbItemMissed < 26) {
						return 1;
				} else {
						return 0;
				}
		}
}