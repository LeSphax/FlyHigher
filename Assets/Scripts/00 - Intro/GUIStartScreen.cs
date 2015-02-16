using UnityEngine;
using System.Collections;

public class GUIStartScreen : MonoBehaviour {

	public float timer;
	private float counter;
    public string sceneToLoad;
	public Texture FlyHigherLogo;
	public Texture EuropFlag;
	public Texture seventh;
	public GUISkin skin400;
	public GUISkin skin500;
	public GUISkin skin600;
	public GUISkin skin700;
	public GUISkin skin800;
	//public GUISkin skin700Right;
	public Color GUIBackGroundColor;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("BuildStep", 5);
		counter = 0;
		MySkin.setSkin (skin800, skin700, skin600, skin500, skin400);
		MySkin.setColor (GUIBackGroundColor);
		PlayerPrefs.SetInt ("MainState", 0);
		PlayerPrefs.SetInt ("Difficulty", 1);
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > timer) {
			Application.LoadLevel(sceneToLoad);
		}
		
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (Screen.width*2/10, Screen.height / 8, Screen.width*6/10, Screen.width * 3/5 * 6 / 7), FlyHigherLogo);
		GUI.DrawTexture (new Rect (Screen.width/10, Screen.height * 7 / 8, Screen.width*2/10, Screen.width * 2/10 * 2 / 3), EuropFlag);
		GUI.DrawTexture (new Rect (Screen.width*6/10, Screen.height * 7 / 8, Screen.width*2/10, Screen.width * 2/10 * 521 / 640), seventh);
		}
}
