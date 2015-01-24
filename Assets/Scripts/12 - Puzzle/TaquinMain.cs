using UnityEngine;
using System.Collections;

public class TaquinMain : MonoBehaviour {

	public int boardSize;
	private int nbTiles;
	public Texture[] texturesTaquin;
	public Texture bg;
	public Texture bgSky;
	public Texture npc;
	private string[] dialogue;
	private int dialogueState;

	private int[][] game;
	private Rect[] positions;
	private Rect test;

	private int state;
	private int selected;
	private int positionFromTop;

	public GUISkin mySkin;
	public GUISkin skinBig;
	public GUIStyle m_MyStyle;
	GameObject temp;
	private Texts texts;

	void Start () {
		if (PlayerPrefs.GetInt ("Difficulty") == 1)
						nbTiles = 5;
				else
						nbTiles = 7;
		texts = new Texts ();
		positionFromTop = (Screen.height - Screen.width) * 2 / 3;
		state = 0;

		dialogue = new string[4];
		dialogue[0] = texts.getText(Quotes.Game12Diag1);
		dialogue[1] = texts.getText(Quotes.Game12Diag2);
		dialogue[2] = texts.getText(Quotes.Game12Diag3);
		dialogue[3] = texts.getText(Quotes.Game12Diag4);

		dialogueState = 0;

		game = new int[boardSize][];
		positions = new Rect[nbTiles];
		for(int i = 0; i < boardSize; i++)
		{
			game[i] = new int[boardSize];
		}
		for (int y = 0; y <boardSize; y++)
		for (int x = 0; x <boardSize; x++) {
			game [y] [x] = -1;
		}


		int xRand;
		int yRand;
		for (int i = 0; i <nbTiles; i++) {
				do {
					xRand = Random.Range (0, 3);
					yRand = Random.Range (0, 3);
				}while(game [yRand] [xRand] != -1);

				game [yRand] [xRand] = i;
				positions [i].x = xRand * Screen.width / 3;
				positions [i].y = yRand * Screen.width / 3 + positionFromTop;
				positions [i].width = Screen.width / 3;
				positions [i].height = Screen.width / 3;
			}
		}

	int getX(int i)
	{
		for (int y = 0; y <boardSize; y++)
		for (int x = 0; x <boardSize; x++) {
			if(game [y] [x] == i)
				return x;
		}
		return -1;
	}

	int getY(int i)
	{
		for (int y = 0; y <boardSize; y++)
		for (int x = 0; x <boardSize; x++) {
			if(game [y] [x] == i)
				return y;
		}
		return -1;
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("PopUp"))
			return;
				if (Input.GetMouseButtonDown (0) && state == 0) {
						for (int i = 0; i <nbTiles; i++)
								if (positions[i].Contains (new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y))) {
										selected = i;
										state = 1;
								}
				} else if (state == 1) {
						//Debug.Log("Input.mousePosition.x : " + Input.mousePosition.x);
						if (!positions [selected].Contains (new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y))) {
										int x = getX (selected);
										int y = getY (selected);
										if (Input.mousePosition.x < positions [selected].x) {
												if (x > 0 && game [y] [x - 1] == -1) {
														positions [selected].x -= Screen.width / 3;
														game [y] [x - 1] = selected;
														game [y] [x] = -1;
												}
										}
										if (Input.mousePosition.x > positions [selected].x + Screen.width / 3) {
												if (x < 2 && game [y] [x + 1] == -1) {
														positions [selected].x += Screen.width / 3;
														game [y] [x + 1] = selected;
														game [y] [x] = -1;
												}
										}
										if (Screen.height - Input.mousePosition.y < positions [selected].y) {
												if (y > 0 && game [y - 1] [x] == -1) {
														positions [selected].y -= Screen.width / 3;
														game [y - 1] [x] = selected;
														game [y] [x] = -1;
												}
										}
										if (Screen.height - Input.mousePosition.y > positions [selected].y + Screen.width / 3) {
												if (y < 2 && game [y + 1] [x] == -1) {
														positions [selected].y += Screen.width / 3;
														game [y + 1] [x] = selected;
														game [y] [x] = -1;
												}
										}
										state = 0;
										PlayerPrefs.SetInt ("TaquinMoves", PlayerPrefs.GetInt ("TaquinMoves")+1);
										if(dialogueState == 0)
				   							dialogueState = 1;
										if (game [0] [1] == 0 && game [1] [0] == 1 && game [1] [1] == 2 && game [1] [2] == 3 && game [2] [1] == 4) {
											PlayerPrefs.SetInt ("TaquinWin", PlayerPrefs.GetInt ("TaquinWin")+1);
											//temp.start();
											PlayerPrefs.Save ();
											dialogueState = 3;
											state = -1;
											//Application.LoadLevel ("StartScreen");
										}
						}
				
				}
		}


	void OnGUI(){
		m_MyStyle = GUI.skin.GetStyle ("Box");
		GUI.skin = MySkin.getSkin();
		GUI.backgroundColor = MySkin.getColor();


		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bgSky);
		GUI.Box (new Rect (Screen.width / 20, Screen.width / 20, Screen.width * 9 / 10, positionFromTop - (Screen.width / 10)), "", m_MyStyle);
		GUI.DrawTexture (new Rect(Screen.width / 10, Screen.width / 10, positionFromTop - (Screen.width / 5), positionFromTop - (Screen.width / 5)), npc);
		GUI.Label(new Rect (Screen.width * 3 / 20 + positionFromTop - (Screen.width / 5), Screen.width / 10, 
		                    (Screen.width * 8 / 10) - (positionFromTop - (Screen.width / 5)), positionFromTop - (Screen.width / 5)), 
		          dialogue[dialogueState]);

			for (int i = 0; i <nbTiles; i++)
				GUI.DrawTexture (positions[i], texturesTaquin[i]);
				GUI.DrawTexture (new Rect(0, positionFromTop, Screen.width, Screen.width), bg);



		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
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
