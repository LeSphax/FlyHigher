using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class StockInteractionPlayer : MonoBehaviour
{

	//public Vector2 velocity = new Vector2 (-3, 0);
	public int scoreValue = 1 ;
		


	enum State
	{
		UNTOUCHED,
		TOUCHED
	}
	private State etat;
	private int idFingerTouched;

	private Vector3 cameraOffsetZ;
	private Vector3 onCarpetPos;
	private Touch currentTouch;
	private Vector3 stwp; // ScreenToWorlPoint
	private Vector2 touchPos;
	private float speed;

	private StockSpawnControllerScript controller;

	void Awake ()
	{
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<StockSpawnControllerScript> ();
	}


	// Use this for initialization
	void Start ()
	{
		etat = State.UNTOUCHED;
		cameraOffsetZ = new Vector3 (0, 0, Camera.main.transform.position.z);
		onCarpetPos = transform.position;
		this.speed = controller.GetSpeed ();

		//renderer = GetComponent<SpriteRenderer> ();
	}
	
	void Update ()
	{
		if (!(Time.timeScale == 0)) {
			foreach (Touch touch in Input.touches) {
				currentTouch = touch;
			
				switch (touch.phase) {
				case TouchPhase.Began:
					stwp = Camera.main.ScreenToWorldPoint (touch.position);
					touchPos = new Vector2 (stwp.x, stwp.y);
								
					if (this.TestHit (touchPos)) {
						this.OnTouchBegan ();
					}
					break;
				case TouchPhase.Moved:
					this.OnTouchDragged ();
//								stwp = Camera.main.ScreenToWorldPoint (touch.position);
//								touchPos = new Vector2 (stwp.x, stwp.y);
//				
//								if (this.TestHit (touchPos)) {
//										this.OnTouchDragOnMe ();
//								}
					break;
				case TouchPhase.Stationary:
					this.OnTouchStayed ();
					break;
				case TouchPhase.Ended:
					this.OnTouchEnded ();
					break;
				}
			}

			onCarpetPos += new Vector3 (-speed, 0, 0) * Time.deltaTime;
			if (etat == State.UNTOUCHED) {
				this.transform.position = onCarpetPos;
			}
		}
	}




	public void OnTouchBegan ()
	{
		switch (etat) {
		case State.UNTOUCHED:
						
			idFingerTouched = currentTouch.fingerId;
			etat = State.TOUCHED;
			break;
		case State.TOUCHED:
			break;
		}
	}

	public void OnTouchDragged ()
	{
		switch (etat) {
		case State.UNTOUCHED:
			break;
		case State.TOUCHED:
			if (idFingerTouched == currentTouch.fingerId) {
				this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (
					currentTouch.position.x, currentTouch.position.y, 0) - cameraOffsetZ);
				etat = State.TOUCHED;
			
			}
			break;
		}
	}

//		public void OnTouchDragOnMe ()
//		{
//				switch (etat) {
//				case State.UNTOUCHED:
//						idFingerTouched = currentTouch.fingerId;
//						etat = State.TOUCHED;
//						break;
//				case State.TOUCHED:
//						if (idFingerTouched == currentTouch.fingerId) {
//								this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (
//					currentTouch.position.x, currentTouch.position.y, 0) - cameraOffsetZ);
//								etat = State.TOUCHED;
//				
//						}
//						break;
//				}
//		}

//		public void OnTouchDraggedAnywhere ()
//		{
//				if (selected) {
//						positionDrag = Camera.main.ScreenToWorldPoint 
//			(new Vector3 (Input.GetTouch (InputMonoTouchScript.idFingerTouch).position.x, Input.GetTouch (InputMonoTouchScript.idFingerTouch).position.y, 0) + cameraOffset);
//						this.transform.position = positionDrag;
//						Debug.Log ("Dragged");
//				}
//		}



	public void OnTouchStayed ()
	{
	}


	public void OnTouchEnded ()
	{
		switch (etat) {
		case State.UNTOUCHED:
			break;
		case State.TOUCHED:
			if (idFingerTouched == currentTouch.fingerId) {
				etat = State.UNTOUCHED;				
			}
			break;
		}
	}

	public void SetSpeed (float newSpeed)
	{
		this.speed = newSpeed;
	}



	bool TestHit (Vector2 touchPos)
	{
		bool xSup = touchPos.x < collider2D.bounds.max.x;
		bool xInf = touchPos.x > collider2D.bounds.min.x;
		bool ySup = touchPos.y < collider2D.bounds.max.y;
		bool yInf = touchPos.y > collider2D.bounds.min.y;

		return xSup && xInf && ySup && yInf;

	}


	
	//		public void OnMouseDown ()
	//		{	
	//				if (selected == false && touchCount == 0) {
	//						Debug.Log ("TouchCount  = " + touchCount);
	//						//touchCount = 1;
	//						selected = true;
	//						cameraOffset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
	//						//Debug.Log ("MouseDown");
	//				}
	//				touchCount++;
	//		}
	//
	//		void OnMouseDrag ()
	//		{
	//				if (selected && touchCount == 1) {
	//						Debug.Log ("MouseDrag");	
	//						transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + cameraOffset;
	//						Debug.Log (transform.position);
	//				}
	//
	//				
	//		}
	//
	//		void OnMouseUp ()
	//		{
	//				if (selected == true) {
	//						selected = false;
	//						
	//						//transform.position = new Vector3 (transform.position, originalPos.y, originalPos.z);
	//						Debug.Log ("MouseUp");
	//				}
	//				touchCount--;
	//		}
}
