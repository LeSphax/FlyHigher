using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ElementToPaintBehavior : MonoBehaviour
{
	private GameControlPaint gameControl;

	private SpriteRenderer rendererEle ;
	private DotColor dotColor;
	

	// Use this for initialization
	void Start ()
	{
		rendererEle = GetComponent<SpriteRenderer> ();
		dotColor = GetComponentInChildren<DotColor> ();
	}

	public void SetController (GameControlPaint g)
	{
		gameControl = g;
	}

	private void SetColor (Color c)
	{
		rendererEle.color = c;
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
		if (!(Time.timeScale == 0)) {
			ColorChanged ();
		}
	}

}
