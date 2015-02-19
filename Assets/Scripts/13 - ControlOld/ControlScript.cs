using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	private string[] dialogue;
	//public Texture bgSky;
	public Texture npc;
	public Texture2D arrowRight;
	public Texture2D arrowLeft;
	public int nbDots;
	//public Texture2D black;
	//public Texture2D radar;
	
	private Rect[] arrows;
	private int angle = 0;
	private int positionFromTop;
	private int dialogueState;
	private bool isClicked;
	private GUIStyle m_MyStyle;
	private int toVisit;
	private float vectorForward;
	private float accuracy;
	private Texts texts;

	

	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Difficulty") == 1)
			accuracy = 0.1f;
		else
			accuracy = 0.05f;
		texts = new Texts ();
		positionFromTop = (Screen.height - Screen.width) * 2 / 3;
		dialogueState = 0;
		vectorForward = 0.25f;
		
		dialogue = new string[4];
		dialogue[0] = texts.getText(Quotes.Game13Diag1);
		dialogue[1] = texts.getText(Quotes.Game13Diag2);
		dialogue[2] = texts.getText(Quotes.Game13Diag3);
		dialogue[3] = texts.getText(Quotes.Game13Diag4);
		
		arrows = new Rect[2];
		arrows[0] = new Rect (Screen.width     / 10, Screen.height * 31 / 40, Screen.width * 3 / 10, Screen.height / 12);
		arrows[1] = new Rect (Screen.width * 6 / 10, Screen.height * 31 / 40, Screen.width * 3 / 10, Screen.height / 12);
		toVisit = nbDots;

		for (int i = 0; i < nbDots; i++) {
			float xdelta = Random.Range (0f, 0.2f);
			float ydelta = Random.Range (0f, 0.2f);
			GameObject.Find ("DotRadar" + i).GetComponent<Transform> ().position = GameObject.Find ("DotRadar" + i).GetComponent<Transform> ().position + new Vector3(xdelta,ydelta);
			}
	}

	private Vector3 SetVectorFromAngle (float x, float y, float z){
		Quaternion rotation = Quaternion.Euler(x, y, z);
		Vector3 up = Vector3.up * 1f;
		return rotation * up;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("PopUp"))
						return;
		if (dialogueState != 3) {
						if (Input.touchCount > 0) {
								if (arrows [0].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
										angle += 1; 
										if (dialogueState == 0)
												dialogueState++;
								}
								if (arrows [1].Contains (new Vector2 (Input.GetTouch (0).position.x, Screen.height - Input.GetTouch (0).position.y))) {
										angle -= 1; 
										if (dialogueState == 0)
												dialogueState++;
								}
							vectorForward = 0.1f;
						}
						else
							vectorForward = 0.25f;

						GameObject.Find ("Plane").GetComponent<Transform> ().transform.localEulerAngles = new Vector3 (0, 0, angle);
						if (Vector3.Distance (GameObject.Find ("Plane").GetComponent<Transform> ().position + SetVectorFromAngle (0, 0, angle) * vectorForward * Time.deltaTime,  
		                      GameObject.Find ("Radar").GetComponent<Transform> ().position) < 0.75f) {
								GameObject.Find ("Plane").GetComponent<Transform> ().transform.position = GameObject.Find ("Plane").GetComponent<Transform> ().position + SetVectorFromAngle (0, 0, angle) * vectorForward * Time.deltaTime;
								//Ray ray = new Ray(GameObject.Find ("Plane").GetComponent<Transform> ().position, );
								//GameObject.Find ("Plane").GetComponent<Transform> ().Translate(new Vector3(
								//	GameObject.Find ("Plane").GetComponent<Transform> ().position = GameObject."Plane").GetComponent<Transform> ().position + 
								//	new Vector3 ((-0.1f * Time.deltaTime), -0.1f * Time.deltaTime, 0);
						}
						
						
						for(int i = 0; i < nbDots; i++)
						if (Vector3.Distance (GameObject.Find ("Plane").GetComponent<Transform> ().position,  
		                     GameObject.Find ("DotRadar" + i).GetComponent<Transform> ().position) < accuracy) {
								toVisit--;
							GameObject.Find ("DotRadar" + i).GetComponent<Transform> ().transform.position = new Vector3 (-10, 0, 0);
						}
						/*if (Vector3.Distance (GameObject.Find ("Plane").GetComponent<Transform> ().position,  
		                      GameObject.Find ("DotRadar1").GetComponent<Transform> ().position) < 0.05f) {
								toVisit--;
								GameObject.Find ("DotRadar1").GetComponent<Transform> ().transform.position = new Vector3 (-10, 0, 0);
						}
						if (Vector3.Distance (GameObject.Find ("Plane").GetComponent<Transform> ().position,  
		                      GameObject.Find ("DotRadar2").GetComponent<Transform> ().position) < 0.05f) {
								toVisit--;
								GameObject.Find ("DotRadar2").GetComponent<Transform> ().transform.position = new Vector3 (-10, 0, 0);
						}*/
			if(toVisit == 1)
				dialogueState = 2;
			if(toVisit == 0)
				dialogueState = 3;
		}
	}
	
	
	void OnGUI() {
		m_MyStyle = GUI.skin.GetStyle ("Box");
		GUI.skin = MySkin.getSkin();
		GUI.backgroundColor = MySkin.getColor();

		GUI.Box (new Rect (Screen.width / 20, Screen.width / 20, Screen.width * 9 / 10, positionFromTop - (Screen.width / 10)), "", m_MyStyle);
		GUI.DrawTexture (new Rect(Screen.width / 10, Screen.width / 10, positionFromTop - (Screen.width / 5), positionFromTop - (Screen.width / 5)), npc);
		GUI.Label(new Rect (Screen.width * 3 / 20 + positionFromTop - (Screen.width / 5), Screen.width / 10, 
		                    (Screen.width * 8 / 10) - (positionFromTop - (Screen.width / 5)), positionFromTop - (Screen.width / 5)), 
		          dialogue[dialogueState]);

		GUI.DrawTexture (arrows[0], arrowLeft);
		GUI.DrawTexture (arrows[1], arrowRight);
		
		
		if(dialogueState != 3)
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 8 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText(Quotes.back))) {
			if(PlayerPrefs.GetInt ("GameFromMenu") == 1){
				PlayerPrefs.SetInt ("MainState", 1);
				Application.LoadLevel ("1 - StartScreen");
			} else {
				Application.LoadLevel ("hangar stape 1");
			}
		}
		if(dialogueState == 3)
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height * 8 / 10 + Screen.height / 12, Screen.width / 2, Screen.height / 12), texts.getText(Quotes.finish))) {
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

