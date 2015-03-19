using UnityEngine;
using System.Collections;

public class ClickOnJar : MonoBehaviour
{
	public Color myColor;

	private GameControlPaint gameControl;

	void Awake ()
	{
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControlPaint> ();
	}

	// Use this for initialization
	void Start ()
	{
		//myColor = Color.blue;
	}

	void OnMouseDown ()
	{
		gameControl.SetSelectedColor (myColor);
	}
}
