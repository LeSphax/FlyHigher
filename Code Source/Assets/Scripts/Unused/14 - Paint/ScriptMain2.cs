using UnityEngine;
using System.Collections;

public class ScriptMain2 : MonoBehaviour {
		private string[] dialogue;
		public Texture bgSky;
		public Texture npc;
		public Texture empty;
	public Texture2D check;
	
		private Texture2D[] myTextureTile;
		
		public Texture2D paintPotRed;
		public Texture2D paintPotGreen;
		public Texture2D paintPotBlue;
		private Rect[] potsPositions;

		public Texture2D[] colorDots;
		public int[] askedColor;

		private int colorSelected;

		private int positionFromTop;
		private int dialogueState;
		private GUIStyle m_MyStyle;
		private int difficulty;


		private Vector2[] squaresPositions;
		private int[] painted;
		private int paintedCount;
		private int tiles;
		private Rect relativePosition;
	private Texts texts;
		
		
		// Use this for initialization
		void Start () {
		texts = new Texts ();
			difficulty = PlayerPrefs.GetInt ("Difficulty");

			positionFromTop = (Screen.height - Screen.width) * 2 / 3;
			dialogueState = 0;
			paintedCount = 0;
			tiles = 48;
			//white = 3, r = 0, g = 1, b = 2
			colorSelected = 0;

			dialogue = new string[4];
			dialogue[0] = texts.getText (Quotes.Game142Diag1);
		dialogue[1] = texts.getText (Quotes.Game142Diag2);
		dialogue[2] = texts.getText (Quotes.Game142Diag3);
		dialogue[3] = texts.getText (Quotes.Game142Diag4);

			squaresPositions = new Vector2[tiles];
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 6; j++) {
						squaresPositions[i*6 + j].x = j;
						squaresPositions[i*6 + j].y = i;
				}

			painted = new int[tiles];
			for (int i = 0; i < painted.Length; i++)
				painted [i] = 3;

			askedColor = new int[tiles];
			for (int i = 0; i < painted.Length; i++)
				askedColor [i] = Random.Range (0, 3);
			
			//Position of pots
			potsPositions = new Rect[3];
			potsPositions[0] = new Rect(Screen.width*8/10, Screen.height*6/16, Screen.width*3/20, Screen.height*1/10);
			potsPositions[1] = new Rect(Screen.width*8/10, Screen.height*8/16, Screen.width*3/20, Screen.height*1/10);
			potsPositions[2] = new Rect(Screen.width*8/10, Screen.height*10/16, Screen.width*3/20, Screen.height*1/10);

			//RelativePosition for tiles
			relativePosition.x = (Screen.width / 10) * 5 / 100;
			relativePosition.y = (Screen.width / 10) * 5 / 100;
			relativePosition.width = (Screen.width / 10) * 90 / 100;
			relativePosition.height = (Screen.width / 10) * 90 / 100;

			//Textures colors for tiles (white, r,g,b).
			myTextureTile = new Texture2D[4];
			myTextureTile[0] = initTextureColor (new Color (1f, 0.25f, 0.25f));
			myTextureTile[1] = initTextureColor (new Color (0.25f, 1f, 0.25f));
			myTextureTile[2] = initTextureColor (new Color (0.25f, 0.25f, 1f));
			myTextureTile[3] = initTextureColor (new Color (1f,1f,1f));
			}

		Texture2D initTextureColor(Color myColor)
		{
			Texture2D myTextureColor = new Texture2D (100, 100);
			Color[] colorTab = myTextureColor.GetPixels ();
			for(var i = 0; i < colorTab.Length; i++)
			{
				colorTab[i] = myColor;
			}
			myTextureColor.SetPixels (colorTab);
			myTextureColor.Apply ();
			return myTextureColor;
		}


		// Update is called once per frame
		void Update () {
		if (GameObject.Find ("PopUp"))
			return;
				if (Input.touchCount > 0) {
						for (int i = 0; i < tiles; i++)
								if (new Rect (Screen.width * (squaresPositions [i].x + 1) / 10, Screen.height / 3 + Screen.width * squaresPositions [i].y / 10, Screen.width / 10, Screen.width / 10).Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
								//normal mode update
								if(difficulty == 1){
									if(askedColor[i] == colorSelected && askedColor[i] != painted[i]){
										paintedCount++;
										painted [i] = colorSelected;
										if(dialogueState == 1)
											dialogueState++;
									}
								//hard mode update
								} else{
									if(askedColor[i] == colorSelected && askedColor[i] != painted[i]){
										paintedCount++;
										painted [i] = colorSelected;
										if(dialogueState == 1)
											dialogueState++;
									}
									else if(askedColor[i] != painted[i])
										painted [i] = colorSelected;
								}
						}
						if (paintedCount == tiles)
								dialogueState = 3;

						for (int i = 0; i < 3; i++)
						if (potsPositions[i].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							if(dialogueState == 0)
								dialogueState++;
							colorSelected = i;
						}
				}
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

			GUI.DrawTexture (potsPositions[0], paintPotRed);
			if(colorSelected == 0)
				GUI.DrawTexture (potsPositions[0], check);
			GUI.DrawTexture (potsPositions[1], paintPotGreen);
			if(colorSelected == 1)
				GUI.DrawTexture (potsPositions[1], check);
			GUI.DrawTexture (potsPositions[2], paintPotBlue);
			if(colorSelected == 2)
				GUI.DrawTexture (potsPositions[2], check);
		
			for (int i = 0; i < tiles; i++) {
					GUI.DrawTexture (new Rect(Screen.width * (squaresPositions[i].x + 1) / 10, Screen.height / 3 + Screen.width * squaresPositions[i].y / 10, 
			                         Screen.width/10, Screen.width/10), empty);

					GUI.DrawTexture (new Rect(Screen.width * (squaresPositions[i].x + 1) / 10 + relativePosition.x, 
						                          Screen.height / 3 + Screen.width * squaresPositions[i].y / 10 + relativePosition.y, 
				                          relativePosition.width, relativePosition.height), myTextureTile[painted[i]]);

					GUI.DrawTexture (new Rect(Screen.width * (squaresPositions[i].x + 1) / 10, Screen.height / 3 + Screen.width * squaresPositions[i].y / 10, 
					                          Screen.width/10, Screen.width/10), colorDots[askedColor[i]]);
			}
			
			
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

