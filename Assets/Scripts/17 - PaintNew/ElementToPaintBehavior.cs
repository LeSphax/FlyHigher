using UnityEngine;
using System.Collections;

public class ElementToPaintBehavior : MonoBehaviour
{
	private GameControlPaint gameControl;

	private SpriteRenderer renderer ;
	private DotColor dotColor;

	void Awake ()
	{
		renderer = GetComponent<SpriteRenderer> ();
		dotColor = GetComponentInChildren<DotColor> ();
		gameControl = GameObject.FindWithTag ("GameController").GetComponent<GameControlPaint> ();
	}

	// Use this for initialization
	void Start ()
	{
	
	}


	private void SetColor (Color c)
	{
		renderer.color = c;
	}


	public void ColorChanged ()
	{
		Color newColor = gameControl.GetSelectedColor ();
		SetColor (newColor);
		dotColor.SetColorUnder (newColor);
		gameControl.CheckGameEnded ();
	}


	void OnMouseDown ()
	{
		Debug.Log ("OnMouseDown");
		ColorChanged ();
	}

}
