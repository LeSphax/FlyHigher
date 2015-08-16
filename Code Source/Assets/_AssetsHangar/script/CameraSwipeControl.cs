using UnityEngine;
using System.Collections;

public class CameraSwipeControl : MonoBehaviour {

	public bool vertical = true;
	public bool horyzontal = true;

	public float verticalSensibility = 0.1f;
	public float horyzontalSensibility = 0.1f;

	public float minX=-10;
	public float maxX=10;
	public float minY=-10;
	public float maxY=10;

	bool android = false;
	Vector3 lastMousePos;//Pc only

	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android)
						android = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (android)
				AndroidUpdate ();
		else
				PCUpdate ();

	}


	void AndroidUpdate()
	{
		if (Input.touchCount <= 0)
			return;
		
		for (int i=0; i<Input.touchCount; i++) 
		{
			Touch tch = Input.GetTouch(i);
			
			if(tch.phase == TouchPhase.Moved)
			{//user is swiping
				
				if(horyzontal)
				{
					transform.Translate( -tch.deltaPosition.x * verticalSensibility, 0, 0);

					if(transform.position.x < minX)
						transform.position = new Vector3(minX, transform.position.y, transform.position.z);
					if(transform.position.x > maxX)
						transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
				}
				
				if(vertical)
				{
					transform.Translate( 0, -tch.deltaPosition.y * horyzontalSensibility, 0);

					if(transform.position.y < minY)
						transform.position = new Vector3(transform.position.x, minY, transform.position.z);
					if(transform.position.y > maxY)
						transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
				}
				
			}
		}
	}


	void PCUpdate()
	{
		if (!Input.GetMouseButton (0)) 
		{
			lastMousePos = Input.mousePosition;
			return;
		}
		Vector3 deltaMouse = lastMousePos - Input.mousePosition;			
		if(horyzontal)
		{
			transform.Translate( deltaMouse.x * verticalSensibility, 0, 0);

			if(transform.position.x < minX)
				transform.position = new Vector3(minX, transform.position.y, transform.position.z);
			if(transform.position.x > maxX)
				transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
		}

		if(vertical)
		{
			transform.Translate( 0, deltaMouse.y * horyzontalSensibility, 0);

			if(transform.position.y < minY)
				transform.position = new Vector3(transform.position.x, minY, transform.position.z);
			if(transform.position.y > maxY)
				transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
		}

		lastMousePos = Input.mousePosition;
	}
}
