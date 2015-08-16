using UnityEngine;
using System.Collections;

public class DotColor : MonoBehaviour
{

	private Color colorUnder;
	private Color colorWanted;
	private SpriteRenderer rendererDot ;
	
	void Awake ()
	{
		rendererDot = GetComponent<SpriteRenderer> ();
	}

	public void SetColorWanted (Color c)
	{
		colorUnder = new Color (1f, 1f, 1f, 1f);
		colorWanted = c;
		rendererDot.color = c;
	}

	public void SetColorUnder (Color c)
	{
		colorUnder = c;
	}

	public bool ColorIsOk ()
	{
		return (colorUnder == colorWanted);
	}
}
