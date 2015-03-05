using UnityEngine;
using System.Collections;

public class StockDestroyObjects : MonoBehaviour
{


		void OnTriggerEnter2D (Collider2D other)
		{
				StockSpawnControllerScript.nbItemMissed++;
				Destroy (other.gameObject);
		}
}
