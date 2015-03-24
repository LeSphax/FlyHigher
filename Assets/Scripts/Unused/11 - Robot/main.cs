using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
		private string[] dialogue;
		public Texture bgSky;
		public Texture npc;
		public Texture2D plane;
		public Texture2D redCursor;
		public Texture2D greenCursor;
		public Texture2D arrowUp;
		public Texture2D arrowDown;
		public Texture2D arrowRight;
		public Texture2D arrowLeft;
		public Texture2D start;
		public Texture2D redDot;
		public Texture2D redLight;
		public Texture2D greenLight;
		public Texture2D goButtonGreen;
		public Texture2D goButtonRed;
		public bool[] targets;

		public Rect[] arrows;
		private Rect horizont;
		private Rect vertical;
		private Rect[] target;
		private Rect goButton;

		private bool hitY;
		private bool hitX;
		private int hitted = -1;
		private int targetsToGo;
		
		private int positionFromTop;
		private int dialogueState;
		private bool isClicked;
		public GUIStyle m_MyStyle;
		private Texts texts;
		
		
		// Use this for initialization
		void Start () {
			positionFromTop = (Screen.height - Screen.width) * 2 / 3;
			dialogueState = 0;
		targetsToGo = 7;
		texts = new Texts ();
		targets = new bool[7];
		for (int i = 0; i < 7; i++)
						targets [i] = false;
		target = new Rect[7];
		target[0] = new Rect (Screen.width * 4 / 10 + 5 * Screen.width / 40,  Screen.height*5/16 + Screen.width * 4 / 10 + 13 * Screen.width / 40, Screen.width / 75,Screen.width / 75);
		target[1] = new Rect (Screen.width * 4 / 10 - 5 * Screen.width / 40,  Screen.height*5/16 + Screen.width * 4 / 10 + 13 * Screen.width / 40, Screen.width / 75,Screen.width / 75);
		target[2] = new Rect (Screen.width * 4 / 10,                          Screen.height*5/16 + Screen.width * 4 / 10 + 5 * Screen.width / 40,  Screen.width / 75,Screen.width / 75);
		target[3] = new Rect (Screen.width * 4 / 10,                          Screen.height*5/16 + Screen.width * 4 / 10 - 4 * Screen.width / 40,  Screen.width / 75,Screen.width / 75);
		target[4] = new Rect (Screen.width * 4 / 10,                          Screen.height*5/16 + Screen.width * 4 / 10 - 12 * Screen.width / 40, Screen.width / 75,Screen.width / 75);
		target[5] = new Rect (Screen.width * 4 / 10 - 13 * Screen.width / 40, Screen.height*5/16 + Screen.width * 4 / 10 + 2 * Screen.width / 40,  Screen.width / 75,Screen.width / 75);
		target[6] = new Rect (Screen.width * 4 / 10 + 13 * Screen.width / 40, Screen.height*5/16 + Screen.width * 4 / 10 + 2 * Screen.width / 40,  Screen.width / 75,Screen.width / 75);

			dialogue = new string[4];
			dialogue[0] = texts.getText(Quotes.Game11Diag1);
			dialogue[1] = texts.getText(Quotes.Game11Diag2);
			dialogue[2] = texts.getText(Quotes.Game11Diag31) + targetsToGo + texts.getText(Quotes.Game11Diag32);
			dialogue[3] = texts.getText(Quotes.Game11Diag4);

			arrows = new Rect[4];
			arrows[0] = new Rect(Screen.width*8/10, Screen.height*5/16, Screen.width*2/10, Screen.height*3/16);
			arrows[1] = new Rect (Screen.width * 8 / 10, Screen.height * 2 / 16 + Screen.width*8/10, Screen.width * 2 / 10, Screen.height * 3 / 16);
			arrows[2] = new Rect (0, Screen.height * 12 / 16, Screen.height * 3 / 16, Screen.width * 2 / 10);
			arrows[3] = new Rect (Screen.width*8/10 - Screen.height * 3 / 16, Screen.height * 12 / 16, Screen.height * 3 / 16, Screen.width * 2 / 10);

			horizont = new Rect (0, Screen.height*5/16 + Screen.width * 4 / 10, Screen.width * 8 / 10, Screen.width / 100);
			vertical = new Rect (Screen.width * 4 / 10, Screen.height*5/16, Screen.width / 100, Screen.width * 8 / 10);
			goButton = new Rect (Screen.width * 6.5f / 10 - Screen.height / 32, Screen.height * 21 / 32, Screen.height * 3 / 32, Screen.height * 3 / 32);
			updateCursor ();
		}
		void updateCursor()
		{
			hitY = false;
			hitX = false;
			hitted = -1;
			for(int i = 0; i < 7; i++){
				//Is Y cursor on a spot?
				if (!targets[i] && horizont.y == target[i].y)
					hitY = true;
				//Is X cursor on a spot?
				if(!targets[i] && vertical.x == target[i].x)
					hitX = true;
				//both on a same spot
				if (!targets[i] && horizont.y == target[i].y && vertical.x == target[i].x){
					hitted = i;
				}
			}
		}
		// Update is called once per frame
		void Update () {
			if (GameObject.Find ("PopUp"))
				return;
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
						
					if (arrows [0].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							if (horizont.y > Screen.height * 5 / 16)
									horizont.y -= Screen.width / 40;
							if (dialogueState == 0)
									dialogueState++;
					}
					if (arrows [1].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							if (horizont.y < Screen.height * 5 / 16 + Screen.width * 8 / 10)
									horizont.y += Screen.width / 40;
							if (dialogueState == 0)
									dialogueState++;
					}
					if (arrows [2].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							if (vertical.x > 0)
									vertical.x -= Screen.width / 40;
							if (dialogueState == 0)
									dialogueState++;
					}
					if (arrows [3].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							if (vertical.x < Screen.width * 8 / 10)
									vertical.x += Screen.width / 40;
							if (dialogueState == 0)
									dialogueState++;
					}

					updateCursor();

					//if he push the goButton and the cursor is on a spot
					if(hitted != -1)
					if (goButton.Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
							targets[hitted] = true;
							targetsToGo--;
							dialogue[2] = texts.getText(Quotes.Game11Diag31) + targetsToGo + texts.getText(Quotes.Game11Diag32);;
							if(dialogueState == 1)
								dialogueState = 2;
							if(targetsToGo == 0)
								dialogueState = 3;
							//Update the cursor again if a point has been hit
							updateCursor();
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
			
			GUI.DrawTexture (new Rect(0, Screen.height*5/16, Screen.width*8/10, Screen.width*8/10), plane);

			if(hitX)
				GUI.DrawTexture (vertical, greenCursor);
			else
				GUI.DrawTexture (vertical, redCursor);
			if(hitY)
				GUI.DrawTexture (horizont, greenCursor);
			else
				GUI.DrawTexture (horizont, redCursor);

		for(int i = 0; i < 7; i++)
			if(targets[i] == false)
				GUI.DrawTexture (target[i], redDot);
			

			GUI.DrawTexture (arrows[0], arrowUp);
			GUI.DrawTexture (arrows[1], arrowDown);
			GUI.DrawTexture (arrows[2], arrowLeft);
			GUI.DrawTexture (arrows[3], arrowRight);

		if(hitted != -1)
			GUI.DrawTexture (goButton, goButtonGreen);
		else
			GUI.DrawTexture (goButton, goButtonRed);



		for(int i = 0; i < 7; i++)
			if(targets[i])
				GUI.DrawTexture (new Rect( (i + 2) * Screen.width/15, Screen.height*5/16 - Screen.width/15,Screen.width/15, Screen.width/15), greenLight);
			else
				GUI.DrawTexture (new Rect( (i + 2) * Screen.width/15, Screen.height*5/16 - Screen.width/15,Screen.width/15, Screen.width/15), redLight);


			
			
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

