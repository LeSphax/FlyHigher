using UnityEngine;
using System.Collections;

public class PaintMain : MonoBehaviour {

	public Texture blue;
	public Texture red;
	public Texture green;
	private string[] dialogue;
	public Texture bgSky;
	public Texture npc;
	public Texture minus;
	public Texture2D loading;
	public Texture2D loadingRed;
	public Texture2D loadingGreen;
	public Texture2D loadingBlue;
	public Texture2D check;

	private int positionFromTop;
	private int dialogueState;
	public GUIStyle m_MyStyle;

	private Texture2D myTexture;
	private Texture2D myTextureResult;

	private Color myColor;
	private float[] rgb;
	private float[] rgbResult;

	private Rect[] colorsPositions;
	private Rect[] loadingPositions;
	private Rect[] loadingColorsPositions;

	private int difficulty;
	private Texts texts;


	// Use this for initialization
	void Start () {
		texts = new Texts ();
		difficulty = PlayerPrefs.GetInt ("Difficulty");
		positionFromTop = (Screen.height - Screen.width) * 2 / 3;
		dialogueState = 0;

		dialogue = new string[4];
		dialogue [0] = texts.getText (Quotes.Game14Diag1);
		dialogue[1] = texts.getText (Quotes.Game14Diag2);
		dialogue[2] = texts.getText (Quotes.Game14Diag3);
		dialogue[3] = texts.getText (Quotes.Game14Diag4);

		colorsPositions = new Rect[3];
		colorsPositions [0].x = Screen.width / 24;
		colorsPositions [0].y = Screen.height / 3;
		colorsPositions [0].height = Screen.height / 6;
		colorsPositions [0].width = Screen.width / 4;
		colorsPositions [1].x = Screen.width * 9 / 24;
		colorsPositions [1].y = Screen.height / 3;
		colorsPositions [1].height = Screen.height / 6;
		colorsPositions [1].width = Screen.width/4;
		colorsPositions [2].x = Screen.width * 17 / 24;
		colorsPositions [2].y = Screen.height / 3;
		colorsPositions [2].height = Screen.height / 6;
		colorsPositions [2].width = Screen.width/4;
		loadingPositions = new Rect[3];
		loadingPositions [0].x = Screen.width / 24;
		loadingPositions [0].y = Screen.height / 2;
		loadingPositions [0].height = Screen.height / 30;
		loadingPositions [0].width = Screen.width / 4;
		loadingPositions [1].x = Screen.width * 9 / 24;
		loadingPositions [1].y = Screen.height / 2;
		loadingPositions [1].height = Screen.height / 30;
		loadingPositions [1].width = Screen.width/4;
		loadingPositions [2].x = Screen.width * 17 / 24;
		loadingPositions [2].y = Screen.height / 2;
		loadingPositions [2].height = Screen.height / 30;
		loadingPositions [2].width = Screen.width/4;
		loadingColorsPositions = new Rect[3];
		loadingColorsPositions [0].x = Screen.width / 24 + Screen.width / 160;
		loadingColorsPositions [0].y = Screen.height / 2 + Screen.height / 300;
		loadingColorsPositions [0].height = Screen.height *2/75;
		loadingColorsPositions [0].width = 0;
		loadingColorsPositions [1].x = Screen.width * 9 / 24 + Screen.width / 160;
		loadingColorsPositions [1].y = Screen.height / 2 + Screen.height / 300;
		loadingColorsPositions [1].height = Screen.height *2/75;
		loadingColorsPositions [1].width = 0;
		loadingColorsPositions [2].x = Screen.width * 17 / 24 + Screen.width / 160;
		loadingColorsPositions [2].y = Screen.height / 2 + Screen.height / 300;
		loadingColorsPositions [2].height = Screen.height *2/75;
		loadingColorsPositions [2].width = 0;


		rgb = new float[3];
		rgb [0] = 0;
		rgb [1] = 0;
		rgb [2] = 0;
		myTexture = new Texture2D (100, 100);
		setColor();

		myTextureResult = new Texture2D (100, 100);
		rgbResult = new float[3];
		for (int i = 0; i < 3; i++) {
			int rand = Random.Range (0, 4);
			if(rand == 3)
				rgbResult [i] = 1f;
			else
				rgbResult [i] = 0.33f * rand;
		}
		Color[] colorTab = myTexture.GetPixels ();
		for(var i = 0; i < colorTab.Length; i++)
		{
			colorTab[i] = new Color(rgbResult[0],rgbResult[1],rgbResult[2]);
		}
		myTextureResult.SetPixels (colorTab);
		myTextureResult.Apply ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("PopUp"))
			return;
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && dialogueState != 3) {
						//if (Input.GetMouseButtonDown (0) && isClicked == false) {
						for (int i = 0; i < 3; i++)
						if (colorsPositions [i].Contains (new Vector2 (Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y))) {
								if((difficulty == 1 && rgb [i] != rgbResult[i]) || difficulty == 2) {
								rgb [i] += 0.33f;
								if(rgb[i] == 0.99f)
									rgb[i] = 1;
								if(rgb[i] > 1)
									rgb[i] = 0;
								loadingColorsPositions [i].width = Screen.width*19/80 * rgb[i];

								
								if(dialogueState == 0)
									dialogueState++;
								}
						}
						myColor = new Color (rgb [0], rgb [1], rgb [2]);
						setColor ();
				}
		if(rgb[0] == rgbResult[0] && rgb[1] == rgbResult[1] && rgb[2] == rgbResult[2])
			dialogueState = 3;
	}

	private void setColor()
	{
		Color[] colorTab = myTexture.GetPixels ();
		for(var i = 0; i < colorTab.Length; i++)
		{
            colorTab[i] = myColor;
		}
		myTexture.SetPixels (colorTab);
		myTexture.Apply ();
	}


	void OnGUI() {
			m_MyStyle = GUI.skin.GetStyle ("Box");
			GUI.skin = MySkin.getSkin();
			GUI.backgroundColor = MySkin.getColor();

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bgSky);
			GUI.Box (new Rect (Screen.width / 20, Screen.width / 20, Screen.width * 9 / 10, positionFromTop - (Screen.width / 10)), "", m_MyStyle);
			GUI.DrawTexture (new Rect(Screen.width / 10, Screen.width / 10, positionFromTop - (Screen.width / 5), positionFromTop - (Screen.width / 5)), npc);
			GUI.Label(new Rect (Screen.width * 3 / 20 + positionFromTop - (Screen.width / 5), Screen.width / 10, 
			                    (Screen.width * 8 / 10) - (positionFromTop - (Screen.width / 5)), positionFromTop - (Screen.width / 5)), 
			          dialogue[dialogueState]);

			GUI.DrawTexture (colorsPositions[0], red);
			if(difficulty == 1 && rgb [0] == rgbResult[0])
				GUI.DrawTexture (colorsPositions[0], check);
			GUI.DrawTexture (colorsPositions[1], green);
			if(difficulty == 1 && rgb [1] == rgbResult[1])
				GUI.DrawTexture (colorsPositions[1], check);
			GUI.DrawTexture (colorsPositions[2], blue);
			if(difficulty == 1 && rgb [2] == rgbResult[2])
				GUI.DrawTexture (colorsPositions[2], check);

			GUI.DrawTexture (loadingPositions[0], loading);
			GUI.DrawTexture (loadingColorsPositions[0], loadingRed);
			GUI.DrawTexture (loadingPositions[1], loading);
			GUI.DrawTexture (loadingColorsPositions[1], loadingGreen);
			GUI.DrawTexture (loadingPositions[2], loading);
			GUI.DrawTexture (loadingColorsPositions[2], loadingBlue);

			GUI.DrawTexture (new Rect (Screen.width/7, Screen.height*13/20, Screen.width*2/7, Screen.width*2/7), myTexture);
			GUI.DrawTexture (new Rect (Screen.width*4/7, Screen.height*13/20, Screen.width*2/7, Screen.width*2/7), myTextureResult);

		if(dialogueState != 3)
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 8 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText (Quotes.back))) {
			if(PlayerPrefs.GetInt ("GameFromMenu") == 1){
				PlayerPrefs.SetInt ("MainState", 1);
				Application.LoadLevel ("1 - StartScreen");
			} else {
				Application.LoadLevel ("hangar stape 1");
			}
		}
		if(dialogueState == 3)
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 8 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText (Quotes.finish))) {
			if(PlayerPrefs.GetInt ("GameFromMenu") == 1){
				PlayerPrefs.SetInt ("MainState", 1);
				Application.LoadLevel ("1 - StartScreen");
			} else {
				PlayerPrefs.SetInt ("BuildStep", (PlayerPrefs.GetInt ("BuildStep")+1)%7);
				Application.LoadLevel ("hangar stape 1");
			}
		}
		}

}
