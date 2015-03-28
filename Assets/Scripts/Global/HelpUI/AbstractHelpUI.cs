using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractHelpUI : MonoBehaviour {
	
	private enum State {First, Medium, Last};
	
	public Button previousButton;
	public Button nextButton;
	public Button exitButton;
	public Image helpImage;
	public Text helpText;
	
	public Sprite[] helpSprites;
	private List <string> helpStrings;
	
	protected string sceneName;
	protected int numberStars;
	protected int level;
	
	protected int min;
	protected int max;
	protected int cursor;
	private State state;
	
	public void Start(){
		GameData gd = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		this.sceneName = Application.loadedLevelName;
		this.numberStars = gd.GetSceneData (this.sceneName).numberStars;
		this.level = gd.GetSceneData (this.sceneName).level;
		this.helpStrings = LanguageText.Instance.GetHelpTexts (sceneName);
		SetMinAndMax ();
		if (min < 0) min = 0;
		if (max >= helpSprites.Length) max = (helpSprites.Length - 1);
		if (ShouldBeVisibleAtLaunch()) Init();
		else gameObject.SetActive(false);
	}
	
	protected abstract void SetMinAndMax();
	
	protected abstract bool ShouldBeVisibleAtLaunch ();
	
	public void InitFromStart (){
		min = 0;
		Init ();
	}
	
	private void Init(){
		if (((max - min) > 0) && helpSprites.Length > 0){
			state = State.First;
			Time.timeScale = 0f;
			cursor = min;
			SetHelpPage();
			SetUIToFirst();
			gameObject.SetActive(true);
		} else {
			gameObject.SetActive(false);
		}
		
	}
	
	private void SetHelpPage(){
		if (cursor < helpSprites.Length)
			helpImage.sprite = helpSprites [cursor];
		if (cursor < helpStrings.Count)
			helpText.text = helpStrings [cursor];
	}
	
	private void SetUIToFirst(){
		previousButton.gameObject.SetActive (false);
		bool b = ((max - min) > 0) && helpSprites.Length > 1;
		nextButton.gameObject.SetActive (b);
		exitButton.gameObject.SetActive (!b);
	}
	
	private void SetUIToMedium(){
		previousButton.gameObject.SetActive (true);
		nextButton.gameObject.SetActive (true);
		exitButton.gameObject.SetActive (false);
	}
	
	private void SetUIToLast(){
		previousButton.gameObject.SetActive (((max - min) > 0) && helpSprites.Length > 1);
		nextButton.gameObject.SetActive (false);
		exitButton.gameObject.SetActive (true);
	}
	
	private void Next(){
		cursor++;
		if ((cursor < max) && (cursor < (helpSprites.Length - 1))) {
			state = State.Medium;
			SetUIToMedium();
		} else {
			state = State.Last;
			SetUIToLast();
		}
		SetHelpPage();
	}
	
	private void Previous(){
		cursor--;
		if (cursor > min){
			state = State.Medium;
			SetHelpPage();
			SetUIToMedium();
		} else {
			state = State.First;
			SetHelpPage();
			SetUIToFirst();
		}
	}
	
	public void NextEventHandler(){
		switch (state){
		case State.First:
			Next();
			break;
		case State.Medium:
			Next();
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
			Previous();
			break;
		case State.Last:
			Previous ();
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

