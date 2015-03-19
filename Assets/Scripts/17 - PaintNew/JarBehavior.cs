using UnityEngine;
using System.Collections;

public class JarBehavior : MonoBehaviour
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

	}

	void OnMouseDown ()
	{
		gameControl.SetSelectedColor (myColor);
	}

	public void SetColor (Color c)
	{
		GetComponentsInChildren<SpriteRenderer> () [1].color = c;
		myColor = c;
	}
}
