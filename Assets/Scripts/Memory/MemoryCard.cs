﻿using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour
{
		
		public static int nbCardSelected;

		GameControllerMemory gameController;
		bool selected;
		int _cardNumber;

		public int cardNumber { 
				get { return _cardNumber; } 
				set { _cardNumber = value; } 
		}


		public void SetMemoryCard (Texture t, int cardNumber)
		{
				renderer.materials [1].mainTexture = t;
				this.cardNumber = cardNumber;
		}



		void Awake ()
		{
				//gameController = Camera.main.GetComponent<GameControllerMemory> ();
		}

		void Start ()
		{
				gameController = Camera.main.GetComponent<GameControllerMemory> ();
				nbCardSelected = 0;
				selected = false;
		}

		public void OnTouchBegan ()
		{
				if (!selected && MemoryCard.nbCardSelected < 2) {
						selected = true;
						MemoryCard.nbCardSelected ++;
						StartCoroutine ("Show");
				}
		}
		

		IEnumerator  Show ()
		{
				animation.Play ("Flip_show");
				yield return new WaitForSeconds (0.75f);
				gameController.CheckCards (this);
			
		}

		public void Hide ()
		{
				MemoryCard.nbCardSelected = 0;
				animation.Play ("Flip_hide");
				selected = false;
		}

		public void RemoveCard ()
		{
				MemoryCard.nbCardSelected = 0;
				animation.Play ("Flip_hide");
				StartCoroutine ("Remove");
		}

		public IEnumerator Remove ()
		{
				yield return new WaitForSeconds (.5f);
				Destroy (gameObject);
		}
}
