﻿using UnityEngine;
using System.Collections;

public class GameControlPaint : MonoBehaviour
{
	public GameObject prefab;
	public Color[] ColorPossible;

	private Color colorSelected = new Color (1f, 1f, 1f, 1f);
	private GameObject draw;
	private DotColor[] dotsColor;

	// Use this for initialization
	void Start ()
	{

		draw = Instantiate (prefab) as GameObject;
		dotsColor = draw.GetComponentsInChildren<DotColor> ();
		foreach (DotColor dc in dotsColor) {
			dc.SetColorWanted (ColorPossible [Random.Range (0, ColorPossible.Length)]);
		}
	}

	public void SetSelectedColor (Color c)
	{
		colorSelected = c;
	}

	public Color GetSelectedColor ()
	{
		return colorSelected;
	}

	public void CheckGameEnded ()
	{
		Debug.Log ("CheckGameEnded");
		for (int i = 0; i < dotsColor.Length; i++) {
			Debug.Log (dotsColor [i].ColorIsOk ());
			if (!(dotsColor [i].ColorIsOk ())) {
				return;
			}
		}
		EndOfGame ();
	}

	public void EndOfGame ()
	{
		Debug.Log ("EndOfGame");
	}
}
