using UnityEngine;
using System.Collections;

public class mainScriptGame10 : MonoBehaviour {

	private string[] dialogue;
	public Texture bgSky;
	public Texture friend;
	public Texture friendSmile;
	public Texture dot;
	public Vector2[] Points;
	public int nbDots;

	private float accuracy;
	private int positionFromTop;
	private int dialogueState;
	private GUIStyle m_MyStyle;
	private LineRenderer myLR;
	private Ray ray;
	private float counter = 0;
	public int currentPoint = 1;
	private int state = 0;
	private Vector3 lastPosition;

	private Texts texts;
	
	
	// Use this for initialization
	void Start () {
		//Set the difficulty of the game
		if (PlayerPrefs.GetInt ("Difficulty") == 1)
			accuracy = 0.5f;
		else
			accuracy = 0.2f;
		positionFromTop = (Screen.height - Screen.width) * 2 / 3;
		dialogueState = 0;
		texts = new Texts ();
		dialogue = new string[4];
		dialogue[0] = texts.getText(Quotes.Game10Diag1);
		dialogue[1] = texts.getText(Quotes.Game10Diag2);
		dialogue[2] = texts.getText(Quotes.Game10Diag3);
		dialogue[3] = texts.getText(Quotes.Game10Diag4);
		myLR = GameObject.Find("Main Camera").GetComponent<LineRenderer>();
		for (int i = 0; i < nbDots; i++) {
			GameObject.Find("Dot" + i).GetComponent<SpriteRenderer>().color = Color.blue;
			float xdelta = Random.Range (-0.7f, 0.7f);
			float ydelta = Random.Range (-0.7f, 0.7f);
			GameObject.Find ("Dot" + i).GetComponent<Transform> ().position = GameObject.Find ("Dot" + i).GetComponent<Transform> ().position + new Vector3(xdelta,ydelta);
		}
		myLR.SetPosition(0,GameObject.Find("Dot0").GetComponent<Transform> ().transform.position);
		myLR.SetPosition(1,GameObject.Find("Dot0").GetComponent<Transform> ().transform.position);
		GameObject.Find("Dot0").GetComponent<SpriteRenderer>().color = Color.green;
		lastPosition = GameObject.Find ("Dot0").GetComponent<Transform> ().transform.position;
	}

	void Update () {
		if (GameObject.Find ("PopUp") || dialogueState == 3)
		   return;
		counter += Time.deltaTime;
		if (counter > 0.5f) {
			if(state == 0){
				GameObject.Find("Dot" + currentPoint%nbDots).GetComponent<SpriteRenderer>().color = Color.red;
				state = 1;
			}
			else {
				GameObject.Find("Dot" + currentPoint%nbDots).GetComponent<SpriteRenderer>().color = Color.blue;
				state = 0;
			}
			counter -= 0.5f;
		}
		if (Input.touchCount > 0 && dialogueState != 3) {
			ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));
			RaycastHit hit; 

			if( Physics.Raycast(ray, out hit)){
				//if we hit the next point, update of data (current point, next point etc..)
				if(Vector3.Distance(hit.point, GameObject.Find("Dot" + currentPoint%nbDots).GetComponent<Transform> ().transform.position) < accuracy){
					if(dialogueState == 0)
						dialogueState++;
					myLR.SetPosition(currentPoint,GameObject.Find("Dot" + currentPoint%nbDots).GetComponent<Transform> ().transform.position);
					GameObject.Find("Dot" + currentPoint%nbDots).GetComponent<SpriteRenderer>().color = Color.green;
					currentPoint++;
					if(currentPoint <= nbDots){
						myLR.SetVertexCount(currentPoint+1);
						myLR.SetPosition(currentPoint,hit.point);}
					else
						dialogueState = 3;
				}
				//or update the point location if not to far away from last position
				else
					if(Vector3.Distance(hit.point, lastPosition) < 0.3f){
						myLR.SetPosition(currentPoint,hit.point);
						lastPosition = hit.point;
						if(GameObject.Find("Sparks").GetComponent<ParticleEmitter> ().emit == false)
							GameObject.Find("Sparks").GetComponent<ParticleEmitter> ().emit = true;
						GameObject.Find("Sparks").GetComponent<Transform> ().transform.position = hit.point;
				}
			}
		}
		else
			GameObject.Find("Sparks").GetComponent<ParticleEmitter> ().emit = false;
	}

	void OnGUI() {
		m_MyStyle = GUI.skin.GetStyle ("Box");
		GUI.skin = MySkin.getSkin();
		GUI.backgroundColor = MySkin.getColor();
		
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bgSky);
		GUI.Box (new Rect (Screen.width / 20, Screen.width / 20, Screen.width * 9 / 10, positionFromTop - (Screen.width / 10)), "", m_MyStyle);

		if(dialogueState != 3)
			GUI.DrawTexture (new Rect(Screen.width / 10, Screen.width / 10, positionFromTop - (Screen.width / 5), positionFromTop - (Screen.width / 5)), friend);
		else
			GUI.DrawTexture (new Rect(Screen.width / 10, Screen.width / 10, positionFromTop - (Screen.width / 5), positionFromTop - (Screen.width / 5)), friendSmile);

		GUI.Label(new Rect (Screen.width * 3 / 20 + positionFromTop - (Screen.width / 5), Screen.width / 10, 
		                    (Screen.width * 8 / 10) - (positionFromTop - (Screen.width / 5)), positionFromTop - (Screen.width / 5)), 
		          dialogue[dialogueState]);

		
		
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

