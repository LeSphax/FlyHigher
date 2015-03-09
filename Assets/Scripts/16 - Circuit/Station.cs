using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Station : Element {

	public enum StationColor{WHITE, BLACK, BLUE, RED}

	public GameObject color;

	public Sprite stationSprite;
	public Sprite selectedStationSprite;

	public Sprite whiteColorSprite;
	public Sprite blackColorSprite;
	public Sprite blueColorSprite;
	public Sprite redColorSprite;

	[HideInInspector] public StationColor stationColor;
	[HideInInspector] public bool isInGame;
	[HideInInspector] public bool isSelected;
	[HideInInspector] public bool isBinded;
	[HideInInspector] public GameObject brotherStation;
	
	private GameObject board;

	public void Init(GameObject board, int x, int y, StationColor sc) {
		Init (board, new Coordinate (x, y), sc);
	}

	public void Init(GameObject board, Coordinate c, StationColor sc) {
		this.board = board;
		this.stationColor = sc;
		base.Init (board, c);

	}
	
	protected override void SetUp (){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.RemoveFreePlace (coordinate);
		bm.stations.Add (gameObject);

		this.isSelected = false;
		this.isBinded = false;
		this.isInGame = true;

		RectTransform rt = GetComponent <RectTransform> ();
		RectTransform cort = color.GetComponent <RectTransform> ();

		cort.SetParent (rt);
		cort.sizeDelta = rt.sizeDelta;
		cort.anchoredPosition = new Vector2 (0f, 0f);
		cort.localScale = new Vector3 (1f, 1f, 1f);
	}

	public override void Draw (){
		Image skin = GetComponent <Image> ();
		Image colorSkin = color.GetComponent <Image> ();
		if (isInGame) {

			if (isSelected) {
				skin.sprite = selectedStationSprite;
			} else {
				skin.sprite = stationSprite;
			}
			color.SetActive(true);
			if (stationColor == StationColor.WHITE){
				colorSkin.sprite = whiteColorSprite;
			} else if (stationColor == StationColor.BLACK) {
				colorSkin.sprite = blackColorSprite;
			} else if (stationColor == StationColor.BLUE) {
				colorSkin.sprite = blueColorSprite;
			} else {
				colorSkin.sprite = redColorSprite;
			}
		} else {
			skin.sprite = stationSprite;
			color.SetActive(false);
		}
	}

	public void StationClicked(){
		board.GetComponent<BoardManager> ().StationClicked (gameObject);
	}
}
