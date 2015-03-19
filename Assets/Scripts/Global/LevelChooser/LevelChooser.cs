using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelChooser : MonoBehaviour {

	public GameObject levelUI;

	public Image panel;
	public Image star1;
	public Image star2;
	public Image star3;

	public AbstractLevel al;
	public int star1LevelNb;
	public int star2LevelNb;
	public int star3LevelNb;

	public GameObject levelButton;
	
	public Sprite emptyStar;
	public Sprite fullStar;

	private GameObject[] star1Buttons = null;
	private GameObject[] star2Buttons = null;
	private GameObject[] star3Buttons = null;
	private string sceneName;

	[HideInInspector] public int levelNb;
	private int lastFinisedLevel;

	[HideInInspector] public float width;
	[HideInInspector] public float height;

	private GameData gameData;

	public void Start(){
		Init ();
	}


	public void Init(){
		sceneName = Application.loadedLevelName;
		RectTransform rt = panel.GetComponent<RectTransform> ();
		width = rt.sizeDelta.x;
		height = rt.sizeDelta.y;
		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		lastFinisedLevel = gameData.GetSceneData (sceneName).level;
		if (lastFinisedLevel == -1) lastFinisedLevel = 0;
		InitStar (star1, 1);
		InitStar (star2, 2);
		InitStar (star3, 3);
		InitButtons (star1Buttons, star1LevelNb, 1, 1);
		InitButtons (star2Buttons, star2LevelNb, 1 + star1LevelNb, 2);
		InitButtons (star3Buttons, star3LevelNb, 1 + star1LevelNb + star2LevelNb, 3);

		SetStarSprite (star1LevelNb, star2LevelNb, star3LevelNb);
	}

	private void SetStarSprite(int star1LevelNb, int star2LevelNb, int star3LevelNb){
		int ns = gameData.GetSceneData (sceneName).numberStars;
		if (ns == 3) {
			star1.sprite = fullStar;
			star2.sprite = fullStar;
			star3.sprite = fullStar;
		} else if (ns == 2){
			star1.sprite = fullStar;
			star2.sprite = fullStar;
			star3.sprite = emptyStar;
		} else if (ns == 1){
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
		levelUI.SetActive (true);
		al.LoadLevel (levelNb);
	}

	public void SaveLevel(){
		string s = ("SAVING LEVEL : " + levelNb);
		if (levelNb < star1LevelNb){
			s += " [1]";
			gameData.AddScoreWithLevel(0, levelNb);
		}else if (levelNb < star1LevelNb + star2LevelNb){
			s += " [2]";
			gameData.AddScoreWithLevel(1, levelNb);
		}else if (levelNb < star1LevelNb + star2LevelNb + star3LevelNb){
			s += " [3]";
			gameData.AddScoreWithLevel(2, levelNb);
		}else {
			s += " [4]";
			gameData.AddScoreWithLevel(3, levelNb);
		}
	}

	public void EndLevel (){
		buttonLoadScene bls = new buttonLoadScene();
		bls.sceneToLoad = sceneName;
		bls.loadScene ();

	}

}
