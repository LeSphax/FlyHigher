using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public abstract class LoaderButton: MonoBehaviour {

	public Button loaderButton;
	public Text titleText;
	public Image lockImage;
	//public Image borderImage; 

	[HideInInspector] public int starsNb;

	protected GameData gameData;
	protected string sceneName;


	protected bool isLocked;

	public void Init(GameData gameData, bool isLocked){
        this.gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		this.isLocked = isLocked;
		this.sceneName = GetComponent<buttonLoadScene> ().sceneToLoad;
		//this.starsNb = gameData.GetSceneData (this.sceneName).numberStars;
        this.titleText.text = LanguageText.Instance.GetSceneName(this.sceneName);
		InitPart ();

		if (this.isLocked) Locks();
		else Unlocks();
	}

	protected abstract void InitPart();

	private void Locks(){
		lockImage.gameObject.SetActive (true);
		LocksPart ();
	}

	protected abstract void LocksPart ();

	private void Unlocks(){
		lockImage.gameObject.SetActive (false);
		ResizePanel (120, 75);
		UnlocksPart ();
	}

	protected abstract void UnlocksPart ();
	
	protected void ResizePanel(int width, int height){
		RectTransform rt = GetComponent<RectTransform> ();
		Vector2 size = rt.sizeDelta;
		size.x = width;
		size.y = height;
		rt.sizeDelta = size;
		//borderImage.rectTransform.sizeDelta = size;
	}
}
