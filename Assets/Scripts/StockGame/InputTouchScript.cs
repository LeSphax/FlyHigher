using UnityEngine;
using UnityEditor;
using System.Collections;

public class InputTouchScript : MonoBehaviour
{
		

		public static Touch currentTouch;


		public GameObject objectConteneurItems;
		private GameObject currentGameObjectTouched;

		private Vector3 cameraOffset;
		private Collider2D hit;
		private Vector3 stwp; // ScreenToWorlPoint
		private Vector2 touchPos;

		// Use this for initialization
		void Start ()
		{		
				currentGameObjectTouched = null;
		}
	
		// Update is called once per frame
		void Update ()
		{
				foreach (Touch touch in Input.touches) {
						currentTouch = touch;

						switch (touch.phase) {
						case TouchPhase.Began:
								stwp = Camera.main.ScreenToWorldPoint (touch.position);
								touchPos = new Vector2 (stwp.x, stwp.y);
								hit = Physics2D.OverlapPoint (touchPos);//, LayerMask.GetMask ("Default"));
								if (hit) {
										currentGameObjectTouched = hit.gameObject;
										currentGameObjectTouched.SendMessage ("OnTouchBegan");
										Debug.Log ("OnTouchBegan");
								}
				//LayerMask.GetMask("Default").
								break;
						case TouchPhase.Moved:
							
								objectConteneurItems.BroadcastMessage ("OnTouchDragged");
								//Debug.Log (touch.fingerId);
								break;
						case TouchPhase.Stationary:
						
								objectConteneurItems.BroadcastMessage ("OnTouchStayed");
			
								break;
						case TouchPhase.Ended:

								objectConteneurItems.BroadcastMessage ("OnTouchEnded");
								break;


						}
				}
		}

	
				
		
}
