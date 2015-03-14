using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelChooser : MonoBehaviour {

	public Image panel;
	public Image star1;
	public Image star2;
	public Image star3;

	public string sceneName;
	public GameObject levelButton;

	public Sprite emptyStar;
	public Sprite fullStar;

	private GameObject[] star1Buttons;
	private GameObject[] star2Buttons;
	private GameObject[] star3Buttons;
	private AbstractLevel al;

	private int levelNb;
	private int lastFinisedLevel;

	[HideInInspector] public float width;
	[HideInInspector] public float height;

	private GameData gameData;

	public void Start(){
		Init (new LevelL(), 1, 2, 3);
	}


	public void Init(AbstractLevel al, int star1LevelNb, int star2LevelNb, int star3LevelNb){
		RectTransform rt = panel.GetComponent<RectTransform> ();
		width = rt.sizeDelta.x;
		height = rt.sizeDelta.y;
		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		lastFinisedLevel = gameData.GetSceneData (sceneName).level;
		if (lastFinisedLevel == -1) lastFinisedLevel = 0;
		this.al = al;
		InitStar (star1, 1);
		InitStar (star2, 2);
		InitStar (star3, 3);
		InitButtons (star1Buttons, star1LevelNb, 1, 1);
		InitButtons (star2Buttons, star2LevelNb, 1 + star1LevelNb, 2);
		InitButtons (star3Buttons, star3LevelNb, 1 + star1LevelNb + star2LevelNb, 3);

		SetStarSprite (star1LevelNb, star2LevelNb, star3LevelNb);
	}

	private void SetStarSprite(int star1LevelNb, int star2LevelNb, int star3LevelNb){
		if (lastFinisedLevel >= (star1LevelNb + star2LevelNb + star3LevelNb)) {
			star1.sprite = fullStar;
			star2.sprite = fullStar;
			star3.sprite = fullStar;
		} else if (lastFinisedLevel >= (star1LevelNb + star2LevelNb)){
			star1.sprite = fullStar;
			star2.sprite = fullStar;
			star3.sprite = emptyStar;
		} else if (lastFinisedLevel >= (star1LevelNb)){
			star1.sprite = fullStar;
			star2.sprite = emptyStar;
			star3.sprite = emptyStar;
		} else {
			star1.sprite = emptyStar;
			star2.sprite = emptyStar;
			star3.sprite = emptyStar;
		}
	}

	private void InitButtons(GameObject []buttons, int buttonsNb, int lvloffset, int starNb){
		float s = (height / 4f);
		float offset = (s / 4f);
		buttons = new GameObject[buttonsNb];
		for (int i = 0; i < buttonsNb; i++) {
			int lvl = i + lvloffset;
			buttons[i] = Instantiate (levelButton) as GameObject;
			buttons[i].GetComponent<LevelButton>().Init(this, lvl, (lvl - 1 > lastFinisedLevel), i, starNb-1, offset);
		}
	}

	private void InitStar(Image star, int starNb){
		float s = (height / 4f);
		float offset = (s / 4f);
		RectTransform rt = star.GetComponent<RectTransform> ();
		rt.SetParent (panel.GetComponent<RectTransform> ());
		rt.sizeDelta = new Vector2 (s, s);
		rt.anchoredPosition = new Vector2 (-(((s) / 2f) + offset), -(((s) / 2f) + ((s + offset) * (starNb-1)) + offset));
		rt.localScale = new Vector3 (1f, 1f, 1f);
	}

	public void LoadLevel(int levelNb){
		this.levelNb = levelNb;
		gameObject.SetActive (false);
		al.LoadLevel (levelNb);
	}

	public void EndLevel (){
		//gameData.AddScoreWithLevel(
	}

}
