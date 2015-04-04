using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JobInfo : MonoBehaviour {

	public Text descriptionText;
	public Text titleText;
	public Button playButton;

	private string sceneToLoadName;


	public void Init(string stln, bool isLocked){
		gameObject.SetActive (true);
		sceneToLoadName = stln;
		titleText.text = LanguageText.Instance.GetSceneName (sceneToLoadName);
		descriptionText.text = LanguageText.Instance.GetJobDescription (sceneToLoadName);
		playButton.GetComponent<buttonLoadScene> ().sceneToLoad = sceneToLoadName;
		if (isLocked) {
			playButton.interactable = false;
		} else {
			playButton.interactable = true;
		}
	}

	public void Return(){
		gameObject.SetActive (false);
	}
}
