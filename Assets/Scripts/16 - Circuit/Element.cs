using UnityEngine;
using System.Collections;


[System.Serializable]
public class Coordinate {
	public int x; 
	public int y;

	public Coordinate (int x, int y){
		this.x = x;
		this.y = y;
	}
}

public abstract class Element : MonoBehaviour {

	[HideInInspector] public Coordinate coordinate;

	public virtual void Init(GameObject board, int x, int y){
		BoardManager bm = board.GetComponent<BoardManager> ();
		RectTransform rt = GetComponent<RectTransform> ();
		int s = bm.size;
		float w = bm.width / ((float) s);
		float h = bm.height / ((float) s);

		coordinate = new Coordinate (x, y);

		rt.SetParent (board.GetComponent<RectTransform> ());
		rt.sizeDelta = new Vector2 (w, h);
		rt.anchoredPosition = new Vector2 (((w / 2f) + (w * coordinate.x)), -((h / 2f) + (h * coordinate.y)));
		rt.localScale = new Vector3 (1f, 1f, 1f);
		SetUp ();
	}

	protected abstract void SetUp ();

	public abstract void Draw ();
}
