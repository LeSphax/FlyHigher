using UnityEngine;
using System.Collections;

public class GameControlPaint : MonoBehaviour
{
	
	public GameObject prefabDrawLvl1;
	public GameObject prefabDrawLvl2;	
	public GameObject prefabDrawLvl3;

	public GameObject prefabColorJar;
	public Color[] ColorPossible;
	public Vector3[] positionJars;

	private JarBehavior jarSelected;
	private Color colorSelected ;
	private DotColor[] dotsColor;

	public void init (int level)
	{
		dotsColor = new DotColor[5];
		colorSelected = new Color (1f, 1f, 1f, 1f);
		GameObject draw;

		switch (level) {
		case 1:
			draw = Instantiate (prefabDrawLvl1) as GameObject;
			break;
		case 2:
			draw = Instantiate (prefabDrawLvl2) as GameObject;
			break;
		case 3:
			draw = Instantiate (prefabDrawLvl3) as GameObject;
			break;
		default:
			draw = Instantiate (prefabDrawLvl1) as GameObject;
			break;
		}

		draw.transform.SetParent (this.transform.parent);
		dotsColor = draw.GetComponentsInChildren<DotColor> ();
		foreach (DotColor dc in dotsColor) {
			dc.SetColorWanted (ColorPossible [Random.Range (0, ColorPossible.Length)]);
		}


		for (int i = 0; i < positionJars.Length; i++) {
			GameObject colorJar = Instantiate (prefabColorJar, positionJars [i], Quaternion.identity) as GameObject;
			JarBehavior jar = colorJar.GetComponentInChildren<JarBehavior> ();
			jar.Start ();
			jar.SetColor (ColorPossible [i]);
			colorJar.transform.SetParent (this.transform.parent);
			jar.SetController (this);
			if (i == 0) {
				SetSelectedJar (jar);
			} else {
				jar.SetSelected (false);
			}
		}

		foreach (ElementToPaintBehavior e in 
		         transform.parent.gameObject.GetComponentsInChildren<ElementToPaintBehavior>()) {
			e.SetController (this);
		}

	}

	public void SetSelectedJar (JarBehavior jar)
	{
		if (jarSelected != null) {
			jarSelected.SetSelected (false);
		}
		jarSelected = jar;
		jarSelected.SetSelected (true);
		colorSelected = jarSelected.GetColor ();
	}

	public Color GetSelectedColor ()
	{
		return colorSelected;
	}

	public void CheckGameEnded ()
	{
		for (int i = 0; i < dotsColor.Length; i++) {
			if (!(dotsColor [i].ColorIsOk ())) {
				return;
			}
		}
		EndOfGame ();
	}

	public void resetLevel ()
	{
		Destroy (transform.parent.gameObject);
	}

	public void EndOfGame ()
	{
		GameObject.FindGameObjectWithTag ("GamesUI").GetComponent<EndLevelGamePopUp> ().LevelEnded ();
	}
}
