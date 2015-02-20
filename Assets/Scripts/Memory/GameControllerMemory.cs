using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerMemory : MonoBehaviour
{

		public GameObject memoryCardPrefab;

		public Texture[] texturesCards;
		public int cardsinrow;


		enum State
		{
				ZEROTOUCH,
				ONETOUCH}
		;	

		private Ray ray;
		private RaycastHit hitInfo = new RaycastHit ();
		private State etat ;
		private MemoryCard[] cards = new MemoryCard[2];
		private int numberPairCards;


		private List<Card> cardsList = new List<Card> ();

		class Card
		{
				public int cardNumber;
				public Texture texture ;

				public Card (Texture texture, int cardNumber)
				{
						this.cardNumber = cardNumber;
						this.texture = texture;
				}
		}



		// Use this for initialization
		void Start ()
		{
				etat = State.ZEROTOUCH;

				for (int i=0; i<texturesCards.Length; i++) {
						Debug.Log ("SetTextures");
						cardsList.Add (new Card (texturesCards [i], i));
						cardsList.Add (new Card (texturesCards [i], i));

				}
				this.numberPairCards = texturesCards.Length;
				if (numberPairCards > 0)
						ShuffleCards ();

		}
	
		// Update is called once per frame
		void Update ()
		{
				
				foreach (Touch touch in Input.touches) {
					
						switch (touch.phase) {
						case TouchPhase.Began:
								ray = Camera.main.ScreenPointToRay (touch.position);

								if (Physics.Raycast (ray, out hitInfo)) {
										hitInfo.transform.gameObject.SendMessage ("OnTouchBegan");
								}
								break;
						}
				}
		}


		void ShuffleCards ()
		{
				List<Card> temp = new List<Card> ();
				int nbCards = (numberPairCards * 2);
				for (int i =0; i< nbCards; i++) {
						int random = Random.Range (0, nbCards - i);
						temp.Add (cardsList [random]);
						cardsList.RemoveAt (random);
				}
		
				cardsList = temp;
				SpawnCards ();
		}


		void SpawnCards ()
		{
				//int cardsinrow = 4;
				int nbCards = (numberPairCards * 2);
				int cardsincolumn = nbCards / cardsinrow;
				if (nbCards % cardsinrow > 0) {
						cardsincolumn += 1;
				}
				float spacebetweencards = .2f;
		
				for (int i=0; i<nbCards; i++) {
						GameObject mc = Instantiate (memoryCardPrefab, new Vector3 ((i % cardsinrow + (i % cardsinrow * spacebetweencards)) - (cardsinrow / 2f) + spacebetweencards, 0,
			                                                            (i / cardsinrow + (i / cardsinrow * spacebetweencards)) - (cardsincolumn / 2f) + spacebetweencards), memoryCardPrefab.transform.rotation) as GameObject;
						mc.GetComponentInChildren<MemoryCard> ().SetMemoryCard (cardsList [i].texture, cardsList [i].cardNumber);
				}
		}


		public void CheckCards (MemoryCard memoryTouched)
		{
				switch (etat) {
				case State.ZEROTOUCH:
						etat = State.ONETOUCH;
						cards [0] = memoryTouched;
						break;
				case State.ONETOUCH:
						cards [1] = memoryTouched;
						if (cards [0].cardNumber == cards [1].cardNumber) {
								CardsMatching ();
						} else {
								CardsNotMatching ();
						}
						etat = State.ZEROTOUCH;
						break;
				}
		}


		void CardsMatching ()
		{
				cards [0].RemoveCard ();
				cards [1].RemoveCard ();
		
				numberPairCards--;
				if (numberPairCards == 0)
						EndOfGame ();
		}


		void CardsNotMatching ()
		{
				cards [0].Hide ();
				cards [1].Hide ();
		}

		void EndOfGame ()
		{

		}
}
