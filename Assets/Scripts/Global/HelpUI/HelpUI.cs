using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HelpUI : MonoBehaviour {

	private enum State {First, Medium, Last};

	public Button prevButton;
	public Button nextButton;
	public Button exitButton;

	public Image helpImage;
	public Text helpText;

	public Sprite[] helpSprites;

	private int i;
	private State state;
	private string sceneName;
	private List<string> helpStrings; 

	public void Start(){ 
		sceneName = Application.loadedLevelName;
		GameData gd = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		bool hasStars = gd.GetSceneData (sceneName).numberStars > 0;
		helpStrings = LanguageText.Instance.GetHelpTexts (sceneName);
		if (!hasStars) Init ();
		else gameObject.SetActive(false);
	}

	public void Init(){
		if (helpSprites.Length > 0){
			Time.timeScale = 0f;
			state = State.First;
			i = 0;
			SetHelpPage ();
			SetUIToFirst ();
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive(false);
		}
	}

	private void SetUIToFirst(){
		prevButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive((helpSprites.Length > 1));
		exitButton.gameObject.SetActive((helpSprites.Length <= 1));
	}

	private void SetUIToMedium(){
		prevButton.gameObject.SetActive(true);
		nextButton.gameObject.SetActive(true);
		exitButton.gameObject.SetActive(false);
	}

	private void SetUIToLast(){
		prevButton.gameObject.SetActive((helpSprites.Length > 1));
		nextButton.gameObject.SetActive(false);
		exitButton.gameObject.SetActive(true);
	}

	private void SetHelpPage(){
		if (i < helpSprites.Length) {
			helpImage.sprite = helpSprites [i];
			if (i < helpStrings.Count)
				helpText.text = helpStrings [i];
		}	
	}

	public void NextEventHandler(){
		switch (state){
		case State.First:
			i++;
			if (i < (helpSprites.Length - 1)){
				state = State.Medium;
				SetHelpPage();
				SetUIToMedium();
			} else {
				state = State.Last;
				SetHelpPage();
				SetUIToLast();
			}
			break;
		case State.Medium:
			i++;
			if (i < (helpSprites.Length - 1)){
				state = State.Medium;
				SetHelpPage();
				SetUIToMedium();
			} else {
				state = State.Last;
				SetHelpPage();
				SetUIToLast();
			}
			break;
		case State.Last:
			//Interdit
			break;
		}
	}

	public void PrevEventHandler(){
		switch (state){
		case State.First:
			//Interdit
			break;
		case State.Medium:
			i--;
			if (i > 0){
				state = State.Medium;
				SetHelpPage();
				SetUIToMedium();
			} else {
				state = State.First;
				SetHelpPage();
				SetUIToFirst();
			}
			break;
		case State.Last:
			i--;
			if (i > 0){
				state = State.Medium;
				SetHelpPage();
				SetUIToMedium();
			} else {
				state = State.First;
				SetHelpPage();
				SetUIToFirst();
			}
			break;
		}
	}

	public void ExitEventHandler(){
		switch (state){
		case State.First:
			if (helpSprites.Length <= 1){
				Time.timeScale = 1.0f;
				gameObject.SetActive(false);
			} else {
				//Interdit
			}
			break;
		case State.Medium:
			//Interdit
			break;
		case State.Last:
			Time.timeScale = 1.0f;
			gameObject.SetActive(false);
			break;
		}
	}
}
