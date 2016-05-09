using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControllerMemory : MonoBehaviour
{

	public GameObject memoryCardPrefab;

	public Texture[] texturesCards;
	public int cardsinrow;
	public Text UILife;
	public AudioClip audioCardsMatching;


	enum State
	{
		ZEROTOUCH,
		ONETOUCH}
	;	

	private Ray ray;
	private RaycastHit hitInfo = new RaycastHit ();
	private State etat ;
	private MemoryCard[] cards = new MemoryCard[2];
	private int numberPairCardsRemaining;
	private int initialNumberPairCard;
	private List<Card> cardsList = new List<Card> ();
	private int currentLife;
	private int initialLife;

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

	void Awake ()
	{
		//labelRate = UIMemory.GetComponentInChildren<Text> ();
	}
	
	void Start ()
	{
		etat = State.ZEROTOUCH;	

		for (int i=0; i<texturesCards.Length; i++) {
			cardsList.Add (new Card (texturesCards [i], i));
			cardsList.Add (new Card (texturesCards [i], i));

		}

		this.numberPairCardsRemaining = texturesCards.Length;
		this.initialNumberPairCard = numberPairCardsRemaining;
		if (numberPairCardsRemaining > 0) {
			ShuffleCards ();
		}

		InitLife ();

	}

	private void InitLife ()
	{
		initialLife = numberPairCardsRemaining * 4;
		currentLife = initialLife;
		UILife.text = currentLife.ToString ();
	}




	void Update ()
	{
        if (!(Time.timeScale == 0))
        {
            if (Input.touchSupported)
            {
                foreach (Touch touch in Input.touches)
                {

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            ray = Camera.main.ScreenPointToRay(touch.position);

                            if (Physics.Raycast(ray, out hitInfo))
                            {
                                hitInfo.transform.gameObject.SendMessage("OnTouchBegan");
                            }
                            break;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        hitInfo.transform.gameObject.SendMessage("OnTouchBegan");
                    }
                }
            }
        }
	}


	void ShuffleCards ()
	{
		List<Card> temp = new List<Card> ();
		int nbCards = (numberPairCardsRemaining * 2);
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
		int nbCards = (numberPairCardsRemaining * 2);
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
		AudioSource.PlayClipAtPoint (audioCardsMatching, transform.position);
		cards [0].RemoveCard ();
		cards [1].RemoveCard ();
		
		numberPairCardsRemaining--;
		if (numberPairCardsRemaining == 0)
			EndOfGame ();
	}


	void CardsNotMatching ()
	{
		cards [0].HideCard ();
		cards [1].HideCard ();
		StartCoroutine ("DecrementLife");
	}

	private IEnumerator DecrementLife ()
	{
		yield return new WaitForSeconds (0.5f);
		currentLife--;
		UILife.text = currentLife.ToString ();
		if (currentLife == 0) {
			EndOfGame ();
		}
	}

	void EndOfGame ()
	{
		GameObject.FindWithTag ("GamesUI").BroadcastMessage ("GameEnded", calculNumberStar ());
	}

	int calculNumberStar ()
	{
		if (currentLife == 0) {
			return 0;
		}

		if (currentLife > initialLife - (initialNumberPairCard + (initialNumberPairCard / 2) + 1)) {
			return 3;
		} else if (currentLife > initialLife - (initialNumberPairCard * 2 + (initialNumberPairCard / 2))) {
			return 2;
		} else {
			return 1;
		}
	}
}
