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
	private bool selected = false;
	private int id;

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
			gameControl.SetSelectedJar (this.id);
		}
	}

	public void SetSelected (bool b)
	{
		selected = b;
		if (b) {
			jarRenderer.sprite = spriteSelected;
		} else {
			jarRenderer.sprite = spriteUnSelected;
		}

	}

	public void SetId (int id)
	{
		this.id = id;
	}

	public void SetColor (Color c)
	{
		paintRenderer.color = c;
		myColor = c;
	}

	public Color GetColor ()
	{
		return myColor;
	}

	public bool isSelected ()
	{
		return selected;
	}
}
