using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public abstract class LoaderButton: MonoBehaviour {

	public Button loaderButton;
	public Text titleText;
	public Image lockImage;
	public Image borderImage;

	protected GameData gameData;
	protected int starsNb;
	//[HideInInspector] public int starsMax;

	private string name;
	private bool isLocked;
	private string title;

	public void Init(GameData gameData, bool isLocked){
		this.gameData = gameData;
		this.isLocked = isLocked;
		this.name = GetComponent<buttonLoadScene> ().sceneToLoad;
		this.starsNb = gameData.GetSceneData (this.name).numberStars;
		//TODO recup le titre avec le nom de la scene
		this.title = this.name;
		this.titleText.text = title;
		InitPart ();

		if (isLocked) Locks();
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
		borderImage.rectTransform.sizeDelta = size;
	}
	/*public virtual void Init (){
		//TODO loadtitle from data
		name = GetComponent<buttonLoadScene>().sceneToLoad;
		gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		title = "Scene";
		titleText.text = title;
		SetStarsNb ();
		if (isLocked) {
			LockButton();
		} else {
			UnlockButton();
		}
	}

	protected virtual void LockButton(){
		Vector2 size = lockImage.rectTransform.sizeDelta;
		Vector2 anchor = lockImage.rectTransform.anchoredPosition;
		loaderButton.interactable = false;
		size.y = 60;
		size.x = 60;
		anchor.y = -15;
		anchor.x = 0;
		lockImage.rectTransform.sizeDelta = size;
		lockImage.rectTransform.anchoredPosition = anchor;
	}

	protected virtual void UnlockButton(){
		//TODO voir si on peut la desactiver
		DisableImage(lockImage);
		loaderButton.interactable = true;

	}

	protected virtual void DisableImage (Image i){
		Vector2 size = i.rectTransform.sizeDelta;
		size.y = 0;
		size.x = 0;
		i.rectTransform.sizeDelta = size;
	}


	protected void SetStarsNb (){
		if (gameData != null && name != null) {
			Debug.Log(name);
			starsNb = 0;
			starsMax = 9;
			try{
				starsNb = gameData.GetSceneData(name).numberStars;
			} catch (KeyNotFoundException KeyNotFoundException) {
				starsNb = 0;	
			}
			try {
				starsMax = gameData.GetBuildingData(name).nbGames * 3;
			} catch (KeyNotFoundException knfe){

			}
		} else {
			starsNb = 0;
			starsMax = 0;
		}
	}
	*/
}
