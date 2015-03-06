using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CircuitGameController : MonoBehaviour {

	public Text debugText;
	public Camera mainCamera;
	private Vector2 touchOrigin = -Vector2.one;	//Used to store location of screen touch origin for mobile controls.

	private void Update ()
	{
		int horizontal = 0;  	//Used to store the horizontal move direction.
		int vertical = 0;		//Used to store the vertical move direction.
		bool moving = true;
		//Check if Input has registered more than zero touches
		if (Input.touchCount > 0)
		{

			//Store the first touch detected.
			Touch myTouch = Input.touches[0];

			//Check if the phase of that touch equals Began
			if (myTouch.phase == TouchPhase.Began)
			{
				//If so, set touchOrigin to the position of that touch
				touchOrigin = myTouch.position;
			}

			//If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
			else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
			{
				moving = false;
				//Set touchEnd to equal the position of this touch
				Vector2 touchEnd = myTouch.position;
				
				//Calculate the difference between the beginning and end of the touch on the x axis.
				float x = touchEnd.x - touchOrigin.x;
				
				//Calculate the difference between the beginning and end of the touch on the y axis.
				float y = touchEnd.y - touchOrigin.y;
				
				//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
				touchOrigin.x = -1;

				//Check if the difference along the x axis is greater than the difference along the y axis.
				if (Mathf.Abs(x) > Mathf.Abs(y)){
					//If x is greater than zero, set horizontal to 1, otherwise set it to -1
					if (Mathf.Abs(x) > ((Screen.width * 2f) /100f))
						if (x > 0) horizontal = 1;
						else if (x < 0) horizontal = -1;

				} else {
					if (Mathf.Abs(y) > ((Screen.height * 2f) /100f))
						if (y > 0) vertical = 1;
						else if (y < 0) vertical = -1; 
				}
			}
				if (horizontal == 0 && vertical == 0) {
					if (moving)
				 		debugText.text = "MOVING";
					else 
					debugText.text = "CLICK";
				} else if (horizontal == 1) {
					debugText.text = "RIGHT";
				} else if (horizontal == -1) {
					debugText.text = "LEFT";
				} else if (vertical == 1) {
				debugText.text = "UP";
				} else if (vertical == -1) {
					debugText.text = "DOWN";
				}
			Vector3 v3 = mainCamera.ScreenToViewportPoint(myTouch.position);
			debugText.text += ": " + v3.x + ", " + v3.y;

		}

	}
}
