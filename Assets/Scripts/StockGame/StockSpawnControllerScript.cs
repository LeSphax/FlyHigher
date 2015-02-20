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
		

		public int itemCount;
		public float spawnWait;
		public float startWait;
		public float waveWait;
		public int nbWavesMax;


		private List<GameObject> itemSpawnnable = new List<GameObject> (); // Liste des différents types d'items qui peuvent actuellement apparaitre

		private int currentWave;
		private float speed;



		// Use this for initialization
		void Start ()
		{
				currentWave = 0;
				speed = 2;
				SpawnBox ();
				SpawnBox ();
				StartCoroutine (SpawnWaves ());
		}


		IEnumerator SpawnWaves ()
		{
				
				yield return new WaitForSeconds (startWait);
				while (currentWave < nbWavesMax) {
						for (int i = 0; i < itemCount; i++) {
								//Quaternion spawnRotation = Quaternion.identity;
								//GameObject item = ;
								Instantiate (itemSpawnnable [Random.Range (0, itemSpawnnable.Count)], spawnPositionsItems [Random.Range (0, spawnPositionsItems.Length)], Quaternion.identity);
						
								yield return new WaitForSeconds (spawnWait);
						}
	
						yield return new WaitForSeconds (waveWait);
						

						spawnWait -= 0.5f;
						//waveWait -= 0.5f;
						currentWave++;
						if (currentWave == 1) {
								SpawnBox ();
						}

						if (currentWave == 2) {
								SpawnBox ();
								speed += 1.5f;
						}

						foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) {
								if (obj.layer == LayerMask.NameToLayer ("Pickable")) {
										obj.GetComponent<StockInteractionPlayer> ().SetSpeed (speed);
								}
						}
				}
				bool notEnd = true;
				while (notEnd) {
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

		private void EndGame ()
		{

				Debug.Log ("GameEnd");
		}
}
