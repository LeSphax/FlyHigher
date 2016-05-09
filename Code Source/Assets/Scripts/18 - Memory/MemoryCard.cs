using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour
{
		
	public static int nbCardSelected;
	public AudioClip audioCardFlip;

	GameControllerMemory gameController;
	bool selected;
	int _cardNumber;



	public int cardNumber { 
		get { return _cardNumber; } 
		set { _cardNumber = value; } 
	}


	public void SetMemoryCard (Texture t, int cardNumber)
	{
		GetComponent<Renderer>().materials [1].mainTexture = t;
		this.cardNumber = cardNumber;
	}



	void Awake ()
	{
		//gameController = Camera.main.GetComponent<GameControllerMemory> ();
	}

	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerMemory> ();
		nbCardSelected = 0;
		selected = false;
	}

	public void OnTouchBegan ()
	{
		if (!selected && MemoryCard.nbCardSelected < 2) {
			selected = true;
			MemoryCard.nbCardSelected ++;
			Show ();
		}
	}
		

	void  Show ()
	{
		GetComponent<Animation>().Play ("Flip_show");
		AudioSource.PlayClipAtPoint (audioCardFlip, transform.position);
			
		gameController.CheckCards (this);
			
	}


	public void HideCard ()
	{
		StartCoroutine ("Hide");
	}

	IEnumerator Hide ()
	{
		yield return new WaitForSeconds (0.75f);
		MemoryCard.nbCardSelected--;
		GetComponent<Animation>().Play ("Flip_hide");
		selected = false;
	}

	public void RemoveCard ()
	{
		MemoryCard.nbCardSelected--;
		GetComponent<Animation>().Play ("Flip_hide");
		StartCoroutine ("Remove");
	}

	IEnumerator Remove ()
	{
		yield return new WaitForSeconds (.5f);
		Destroy (gameObject);
	}
}
