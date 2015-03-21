using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JarBehavior : MonoBehaviour
{
	public Color myColor;
	public Sprite spriteSelected;
	public Sprite spriteUnSelected;

	private GameControlPaint gameControl;

	private	SpriteRenderer paintRenderer ;
	private SpriteRenderer jarRenderer;

	public void Start ()
	{
		jarRenderer = GetComponentsInChildren<SpriteRenderer> () [0];
		paintRenderer = GetComponentsInChildren<SpriteRenderer> () [1];
	}

	public void SetController (GameControlPaint g)
	{
		gameControl = g;
	}

	void OnMouseDown ()
	{
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			gameControl.SetSelectedJar (this);
		}
	}

	public void SetSelected (bool b)
	{
		if (b) {
			jarRenderer.sprite = spriteSelected;
		} else {
			jarRenderer.sprite = spriteUnSelected;
		}
	}

	public void SetColor (Color c)
	{
		GetComponentsInChildren<SpriteRenderer> () [1].color = c;
		myColor = c;
	}

	public Color GetColor ()
	{
		return myColor;
	}
}
