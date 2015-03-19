using UnityEngine;
using System.Collections;

public class DotColor : MonoBehaviour
{

	private Color colorUnder;
	private Color colorWanted;
	private SpriteRenderer renderer ;
	
	void Awake ()
	{
		renderer = GetComponent<SpriteRenderer> ();
	}

	public void SetColorWanted (Color c)
	{
		colorWanted = c;
		renderer.color = c;
	}

	public void SetColorUnder (Color c)
	{
		colorUnder = c;
	}

	public bool ColorIsOk ()
	{
		if (colorUnder == null || colorWanted == null) {
			return false;
		}
		return (colorUnder == colorWanted);
	}
}
