using UnityEngine;
using System.Collections;

public class StockSpawnControllerScript : MonoBehaviour
{
		public GameObject[] items;
		public Vector3[] spawnPositionsItems;
		public GameObject[] box;
		public Vector3[] spawnPositionsBox;

		public int itemCount;
		public float spawnWait;
		public float startWait;
		public float waveWait;
		public int nbWavesMax;


		private int currentWave;
		private int speed;

		// Use this for initialization
		void Start ()
		{
				speed = 2;
				StartCoroutine (SpawnWaves ());
		}


		IEnumerator SpawnWaves ()
		{
				
				yield return new WaitForSeconds (startWait);
				while (currentWave < nbWavesMax) {
						for (int i = 0; i < itemCount; i++) {
								//Quaternion spawnRotation = Quaternion.identity;
								//GameObject item = ;
								Instantiate (items [Random.Range (0, items.Length)], spawnPositionsItems [Random.Range (0, spawnPositionsItems.Length)], Quaternion.identity);
						

								yield return new WaitForSeconds (spawnWait);
//			
						}
						//			while(currentNumberOfItem > 0){
						//				yield return new WaitForSeconds(waveWait);
						//		
						yield return new WaitForSeconds (waveWait);
						speed += 3;
						foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) {
								if (obj.layer == LayerMask.NameToLayer ("Pickable")) {
										obj.GetComponent<StockInteractionPlayer> ().SetSpeed (speed);
								}
						}
						spawnWait -= 0.5f;
						waveWait -= 0.5f;
						currentWave++;
				}
	


		}

		public int GetSpeed ()
		{
				return this.speed;
		}
}
