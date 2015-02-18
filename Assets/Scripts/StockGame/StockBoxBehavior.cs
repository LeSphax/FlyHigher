using UnityEngine;
using System.Collections;

public class StockBoxBehavior : MonoBehaviour
{

		public string typeBox;
	
		void OnTriggerEnter2D (Collider2D other)
		{	
				Debug.Log ("TriggerEnter");
				if (other.tag == typeBox) {
						other.SendMessage ("OnDestroy");
						Destroy (other.gameObject);
				}
		}
}
