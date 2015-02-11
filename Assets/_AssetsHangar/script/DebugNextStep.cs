using UnityEngine;
using System.Collections;

public class DebugNextStep : MonoBehaviour {

	public GameObject[] lstObjStep;
	public int currentStep = 0;
	public int buildStep;
	public Texture2D background;
	private int dialogueStep = 0;
	private Texts texts;
	private string dialogue;
	private int difficulty;

	// Use this for initialization
	void Start () {
		texts = new Texts ();
		difficulty = PlayerPrefs.GetInt ("Difficulty");
		currentStep= PlayerPrefs.GetInt ("BuildStep");

		if (currentStep == 0)
			dialogue = texts.getText (Quotes.BuildDiag0);
		else if (currentStep == 1)
			dialogue = texts.getText (Quotes.BuildDiag1);
		else if (currentStep == 2)
			dialogue = texts.getText (Quotes.BuildDiag2);
		else if (currentStep == 3)
			dialogue = texts.getText (Quotes.BuildDiag3);
		else if (currentStep == 4)
			dialogue = texts.getText (Quotes.BuildDiag4);
		else if (currentStep == 5)
			dialogue = texts.getText (Quotes.BuildDiag5);
		else if (currentStep == 6)
			dialogue = texts.getText (Quotes.BuildDiag6
			                          );

		for (int i=0; i<lstObjStep.Length; i++) {
			lstObjStep[i].SetActive(false);		
		}
		lstObjStep[currentStep > 4? currentStep-1 : currentStep].SetActive(true);

	}
	
	void OnMouseDown()
	{
		/*currentStep++;
		if (currentStep >= lstObjStep.Length)
						currentStep = 0;
		for (int i=0; i<lstObjStep.Length; i++) {
			lstObjStep[i].SetActive(false);		
		}
		lstObjStep[currentStep].SetActive(true);*/
	}

	void OnGUI()
	{
		GUI.skin = MySkin.getSkin();
		GUI.backgroundColor = MySkin.getColor();

		if(dialogueStep == 0)
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 7 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText(Quotes.Speak))) {
			dialogueStep++;
		}
		if (dialogueStep == 1) {
			//if the user pushed talk button, display text and new button to play
			Texture2D oldBackground = GUI.skin.textArea.normal.background;
			
			GUI.skin.textArea.normal.background = background;
			GUI.TextArea ( new Rect(Screen.width/8, Screen.height/15, Screen.width*6/8, Screen.height/6)  , dialogue);
			GUI.skin.textArea.normal.background = oldBackground;
			if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 7 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText(Quotes.Help))) {
					PlayerPrefs.SetInt ("GameFromMenu", 0);
					if (currentStep == 0)
						Application.LoadLevel ("10 - shape");
					else if (currentStep == 1)
						Application.LoadLevel ("11 - Robot");
					else if (currentStep == 2)
						Application.LoadLevel ("12 - Puzzle");
					else if (currentStep == 3)
						Application.LoadLevel ("13 - Control");
					else if (currentStep == 4)
						Application.LoadLevel ("14 - Paint");
					else if (currentStep == 5)
						Application.LoadLevel ("14 - Paint 2");
					else if (currentStep == 6){
						currentStep = 0;
						PlayerPrefs.SetInt ("BuildStep", 0);
						lstObjStep[5].SetActive(false);	
						lstObjStep[0].SetActive(true);
						dialogue = texts.getText (Quotes.BuildDiag0);
					}

			}		
			}

		if (difficulty == 1){
				if (GUI.Button (new Rect (Screen.width*11 / 20, Screen.height * 8 / 10 + Screen.height / 12, Screen.width * 9 / 20, Screen.height / 12), texts.getText(Quotes.DifficultyNormalShort))) {
				PlayerPrefs.SetInt ("Difficulty", 2);
				difficulty = 2;
				}
			} else {
				if (GUI.Button (new Rect (Screen.width*11 / 20, Screen.height * 8 / 10 + Screen.height / 12, Screen.width * 9 / 20, Screen.height / 12), texts.getText(Quotes.DifficultyHardShort))) {
				PlayerPrefs.SetInt ("Difficulty", 1);
				difficulty = 1;
			}
		}
		if (GUI.Button (new Rect (Screen.width / 20, Screen.height * 8 / 10 + Screen.height / 12, Screen.width * 9 / 20, Screen.height / 12), "Menu")) {
			PlayerPrefs.SetInt ("BuildStep", currentStep);
			PlayerPrefs.SetInt ("MainState", 0);
			Application.LoadLevel ("1 - StartScreen");
		}
	}
}
