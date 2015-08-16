using UnityEngine;
using System.Collections;

public class GameControlPaint : MonoBehaviour
{


	public Color ColorBlue = new Color (0.31f, 0.31f, 1f, 1f);
	public static Color ColorRed = new Color (1f, 0.31f, 0.31f, 1f);
	public static Color ColorYellow = new Color (1f, 1f, 0.31f, 1f);
	public static Color ColorOrange = new Color (1f, 0.5f, 0.2f, 1f);
	public static Color ColorGreen = new Color (0.31f, 0.88f, 0.31f, 1f);
	public static Color ColorPurple = new Color (0.88f, 0.31f, 1f, 1f);
	public static Color ColorWhite = new Color (1f, 1f, 1f, 1f);


	public GameObject prefabUIAeronautic;
	public GameObject prefabDrawLvl1;
	public GameObject prefabDrawLvl2;	
	public GameObject prefabDrawLvl3;
	public GameObject prefabColorJar;
	public GameObject prefabMix;

	public Vector3[] positionJars;
	public Vector3 positionMix;

	private Color[] colorPossible;
	private JarBehavior[] tabJar = new JarBehavior[3];
	private int indiceYoungJar;
	private int indiceOldJar;
	private Color colorSelected ;
	private DotColor[] dotsColor;
	private int nbSelected ;
	private SpriteRenderer mixArea;

	private int currentLevel;
	private int lvlMixEnable = 3;

	public void Update ()
	{

	}

	public void init (int level)
	{
		indiceYoungJar = -1;
		indiceOldJar = -1;
		this.nbSelected = 0;
		colorPossible = new Color[3];
		colorPossible [0] = ColorRed;
		colorPossible [1] = ColorBlue;
		colorPossible [2] = ColorYellow;


		this.currentLevel = level;
		dotsColor = new DotColor[5];
		colorSelected = ColorWhite;
		GameObject draw;
		GameObject mix;
		switch (level) {
		case 1:
			draw = Instantiate (prefabDrawLvl1) as GameObject;
			break;
		case 2:
			draw = Instantiate (prefabDrawLvl2) as GameObject;
			break;
		case 3:
			draw = Instantiate (prefabDrawLvl3) as GameObject;
			mix = Instantiate (prefabMix, positionMix, Quaternion.identity) as GameObject;
			mixArea = mix.GetComponent<SpriteRenderer> ();
			break;
		default:
			draw = Instantiate (prefabDrawLvl1) as GameObject;
			break;
		}

		draw.transform.SetParent (this.transform.parent);
		dotsColor = draw.GetComponentsInChildren<DotColor> ();
		foreach (DotColor dc in dotsColor) {
			if (currentLevel >= lvlMixEnable) {
				dc.SetColorWanted (MixColor (colorPossible [Random.Range (0, colorPossible.Length)], 
				                             colorPossible [Random.Range (0, colorPossible.Length)]));
			} else {
				dc.SetColorWanted (colorPossible [Random.Range (0, colorPossible.Length)]);
			}
		}


		for (int i = 0; i < positionJars.Length; i++) {
			GameObject colorJar = Instantiate (prefabColorJar, positionJars [i], Quaternion.identity) as GameObject;
			tabJar [i] = colorJar.GetComponentInChildren<JarBehavior> ();
			tabJar [i].Start ();
			tabJar [i].SetColor (colorPossible [i]);
			tabJar [i].SetId (i);
			colorJar.transform.SetParent (this.transform.parent);
			tabJar [i].SetController (this);
			tabJar [i].SetSelected (false);
		}

		foreach (ElementToPaintBehavior e in 
		         transform.parent.gameObject.GetComponentsInChildren<ElementToPaintBehavior>()) {
			e.SetController (this);
		}

	}

	private Color MixColor (Color c1, Color c2)
	{
		if (c1 == c2) {
			return c1;
		}

		if ((c1 == ColorYellow && c2 == ColorBlue) || (c1 == ColorBlue && c2 == ColorYellow)) {
			return ColorGreen;
		}

		if ((c1 == ColorBlue && c2 == ColorRed) || (c1 == ColorRed && c2 == ColorBlue)) {
			return ColorPurple;
		}

		if ((c1 == ColorRed && c2 == ColorYellow) || (c1 == ColorYellow && c2 == ColorRed)) {
			return ColorOrange;
		}

		return ColorWhite;
	}

	public void SetSelectedJar (int i)
	{
		if (currentLevel < lvlMixEnable) {
			if (indiceYoungJar != -1) {
				tabJar [indiceYoungJar].SetSelected (false);
			}
			indiceYoungJar = i;
			tabJar [i].SetSelected (true);
			colorSelected = tabJar [i].GetColor ();
		
		} else {

			if (nbSelected == 0) {
				indiceYoungJar = i;
				tabJar [i].SetSelected (true);
				nbSelected++;
				colorSelected = tabJar [i].GetColor ();

			} else if (nbSelected == 1) {
				if (tabJar [i].isSelected ()) {
					tabJar [i].SetSelected (false);
					nbSelected--;
					colorSelected = ColorWhite;
				} else {
					indiceOldJar = indiceYoungJar;
					indiceYoungJar = i;
					tabJar [i].SetSelected (true);
					nbSelected++;
					colorSelected = MixColor (colorSelected, tabJar [i].GetColor ());
				}
				
			} else if (nbSelected == 2) {
				if (tabJar [i].isSelected ()) {
					if (tabJar [i] == tabJar [indiceYoungJar]) {
						indiceYoungJar = indiceOldJar;
					}
					tabJar [i].SetSelected (false);
					nbSelected--;
					for (int j =0; j < tabJar.Length; j++) {
						if (tabJar [j].isSelected ()) {
							colorSelected = tabJar [j].GetColor ();
							break;
						}
					}
				} else {
					tabJar [indiceOldJar].SetSelected (false);
					indiceOldJar = indiceYoungJar;
					indiceYoungJar = i;
					tabJar [i].SetSelected (true);
					colorSelected = MixColor (tabJar [indiceYoungJar].GetColor ()
					                          , tabJar [indiceOldJar].GetColor ());
				}
			}
			mixArea.color = colorSelected;
		}

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
		StartCoroutine ("EndOfGame");
	}

	public void resetLevel ()
	{
		Destroy (transform.parent.gameObject);
	}

	IEnumerator EndOfGame ()
	{
		GameObject UIAero = Instantiate (prefabUIAeronautic) as GameObject;
		UIAero.transform.SetParent (this.transform.parent);
		yield return new WaitForSeconds (0.1f);
		float t1 = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < t1 + 2f) {
		}
		Destroy (UIAero);
		yield return new WaitForSeconds (0.1f);
		GameObject.FindGameObjectWithTag ("GamesUI").GetComponentInChildren<EndLevelGamePopUp> ().LevelEnded ();
	}
}
