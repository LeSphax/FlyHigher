using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class LoaderButton: MonoBehaviour {

	public Button loaderButton;
	public Text titleText;
	public Image lockImage;
	public Image borderImage;

	[HideInInspector] public bool isLocked;
	[HideInInspector] public string name;
	[HideInInspector] public GameData gameData;
	[HideInInspector] public int starsNb;
	[HideInInspector] public int starsMax;

	private string title;

	public virtual void Init (){
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

	protected void ResizePanel(int width, int height){
		RectTransform rt = GetComponent<RectTransform> ();
		Vector2 size = rt.sizeDelta;
		size.x = width;
		size.y = height;
		rt.sizeDelta = size;
		borderImage.rectTransform.sizeDelta = size;
	}

	protected void SetStarsNb (){
		if (gameData != null && name != null) {
			Debug.Log(name);
			starsNb = 0;
			starsMax = 9;
			/*try{
				starsNb = gameData.GetSceneData(name).starsNb;
			} catch (KeyNotFoundException KeyNotFoundException) {
				starsNb = 0;	
			}*/
			/*try {
				//starsMax = gameData.GetBuildingData(name).maxStars;
			} catch (KeyNotFoundException knfe){

			}*/
		} else {
			starsNb = 0;
			starsMax = 0;
		}
	}

}
