using UnityEngine;
using System.Collections;

public class GamesListGUI : MonoBehaviour
{
		private Vector2 definition;
		public GUIStyle m_MyStyle;
		public GUIStyle transparent;
		public Color GUIBackGroundColor;
		public Texture Settings;
		//public Texture Trophies;
		//public Texture Stats;
		public Texture PlayGames;
		public Texture PlayConstruct;
		public Texture FlyHigherText;
		public Texture seventh;
		public Texture ics;
		public Texture2D beta;
		public Texture2D backgroundSettings;

		public Texture[] achievements;

		public Texture[] friends;

		private int difficulty;



		private float deltaXGUIMain;
		private float deltaXGUIComponent;
		private int state;
		private Vector4 posPlay;
		private Vector4 posBuil;
		private Vector4 posCcpt;
		private Vector4 posAchv;
		private Vector4 posSett;
		//Vector2 scrollPosition = Vector2.zero;

		public const int StateMain = 0;

		public const int StateMainToGames = 11;
		public const int StateGames = 10;
		public const int StateGamesToMain = 12;

		public const int StateMainToAchievements = 21;
		public const int StateAchievements = 20;
		public const int StateAchievementsToMain = 22;

		public const int StateMainToConstruct = 31;
		public const int StateConstruct = 30;
		public const int StateConstructToMain = 32;

		public const int StateMainToSettings = 41;
		public const int StateSettings = 40;
		public const int StateSettingsToMain = 42;

		public const int StateMainToStats = 51;
		public const int StateStats = 50;
		public const int StateStatsToMain = 52;

		private Texts texts;

		void Start ()
		{
				texts = new Texts ();
				definition.x = Screen.width;
				definition.y = Screen.height;

		posPlay.w = Screen.width / 2;
				posPlay.x = Screen.height * 8 / 10;
				posPlay.y = Screen.width / 2;
				posPlay.z = Screen.height / 6;
		posBuil.w = 0;
				posBuil.x = Screen.height * 8 / 10;
				posBuil.y = Screen.width / 2;
				posBuil.z = Screen.height / 12;
				posCcpt.w = 0;
				posCcpt.x = Screen.height * 8 / 10 + Screen.height / 12;
				posCcpt.y = Screen.width / 2;
				posCcpt.z = Screen.height / 12;
				posAchv.w = Screen.width / 2;
				posAchv.x = Screen.height * 8 / 10 - Screen.height / 12;
				posAchv.y = Screen.width / 2;
				posAchv.z = Screen.height / 12;
				posSett.w = Screen.width * 3 / 4;
				posSett.x = Screen.height * 8 / 10 - 2 * Screen.height / 12;
				posSett.y = Screen.width / 2;
				posSett.z = Screen.height / 12;

				int stateInit = PlayerPrefs.GetInt ("MainState");
				if (stateInit == 1) {
						deltaXGUIMain = Screen.width;
						deltaXGUIComponent = 0;
						state = StateGames;
				}
				else {
					deltaXGUIMain = 0;
					deltaXGUIComponent = -Screen.width;
					state = 0;
				}
				difficulty = PlayerPrefs.GetInt ("Difficulty");
				PlayerPrefs.SetInt ("GameFromMenu", 1);
		}
	
		// Update is called once per frame
		void Update () {
			if (state%10 == 1)
				if (deltaXGUIMain + Screen.width * Time.deltaTime*2 < Screen.width) {
					deltaXGUIMain += Screen.width * Time.deltaTime*2;
					deltaXGUIComponent += Screen.width * Time.deltaTime*2;
				} else {
					deltaXGUIMain = Screen.width;
					deltaXGUIComponent = 0;
					state--;
				}
			if (state%10 == 2)
				if (deltaXGUIMain - Screen.width * Time.deltaTime*2 > 0) {
					deltaXGUIMain -= Screen.width * Time.deltaTime*2;
					deltaXGUIComponent -= Screen.width * Time.deltaTime*2;
				} else {
					deltaXGUIMain = 0;
					deltaXGUIComponent = -Screen.width;
					state = 0;
				}
			if (state == StateSettings) {
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
					Rect r = new Rect(Screen.width*2/10 + deltaXGUIComponent, Screen.height*8/10 - Screen.width*2/10, Screen.width*2/10, Screen.width*2/10);
					if (r.Contains(new Vector2 (Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y))) {
					Application.OpenURL("http://www.flyhigher.eu/");
					//state = 0;
				}
			}
		}
	}

	void OnGUI ()
	{
		m_MyStyle = GUI.skin.GetStyle ("Button");
		GUI.backgroundColor = GUIBackGroundColor;
		GUI.skin = MySkin.getSkin();

		//GUI Main
		if(state == StateMain || state%10 != 0){
			drawGUIMain();
		}
		
		//GUI Games
		if(state == StateMainToGames || state == StateGames || state == StateGamesToMain){
			drawGames();
		}

		//GUI Achievements
		if (state == StateMainToAchievements || state == StateAchievements || state == StateAchievementsToMain) {
			drawAchievement();
		}
		//GUI Construct
		if(state == StateMainToConstruct || state == StateConstruct || state == StateConstructToMain) {
			drawConstruct();
		}

		//GUI Settings
		if(state == StateMainToSettings || state == StateSettings || state == StateSettingsToMain) {
			drawSettings();
		}

		//GUI Stats
		if(state == StateMainToStats || state == StateStats || state == StateStatsToMain) {
			drawStats();
		}
		GUI.DrawTexture (new Rect(0, 0,Screen.width / 4, Screen.width / 80 * 23), beta);
	}

	private void drawGUIMain()
	{
		GUI.skin.button.alignment = TextAnchor.MiddleRight;
		GUI.DrawTexture (new Rect(Screen.width/10 + deltaXGUIMain, Screen.width/5,Screen.width * 8 / 10, Screen.width  / 5), FlyHigherText);
		if (GUI.Button (new Rect (posPlay.w + deltaXGUIMain, posPlay.x, posPlay.y, posPlay.z), texts.getText(Quotes.play))) {
			if (state == StateMain)
				state = StateMainToGames;
		}
		GUI.DrawTexture (new Rect(posPlay.w - GUI.skin.button.contentOffset.x + deltaXGUIMain, posBuil.x + posBuil.z/2, Screen.width/6, Screen.width/6), PlayGames);
		
		if (GUI.Button (new Rect (posBuil.w + deltaXGUIMain, posBuil.x, posBuil.y, posPlay.z), texts.getText(Quotes.build))) {
			if (state == StateMain){
				GUI.skin.button.alignment = TextAnchor.MiddleCenter;
				Application.LoadLevel ("hangar stape 1");
			}
		}
		GUI.DrawTexture (new Rect(posBuil.w - GUI.skin.button.contentOffset.x + deltaXGUIMain, posBuil.x + posBuil.z/2, Screen.width/6, Screen.width/6), PlayConstruct);
		
		//if (GUI.Button (new Rect (posAchv.w + deltaXGUIMain, posAchv.x - Screen.height / 50, Screen.width  / 6, Screen.width  / 6), Trophies, transparent)) {
		//	if (state == StateMain)
		//		state = StateMainToAchievements;
		//}
		//if (GUI.Button (new Rect (posAchv.w + Screen.width * 1  / 6 + deltaXGUIMain, posAchv.x - Screen.height / 50, Screen.width  / 6, Screen.width  / 6), Stats, transparent)) {
		//	if (state == StateMain)
		//		state = StateMainToStats;
		//}
		if (GUI.Button (new Rect (posAchv.w + Screen.width * 2  / 6 + deltaXGUIMain, posAchv.x - Screen.height / 50, Screen.width  / 6, Screen.width  / 6), Settings, transparent)) {
			if (state == StateMain)
				state = StateMainToSettings;
		}
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
	}

	private void drawGames()
	{
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (Screen.width * 2 / 10 + deltaXGUIComponent, Screen.height * 7 / 8, Screen.width * 6 / 10, Screen.height / 10), "Back")) {
			if (state == StateGames)
				state = StateGamesToMain;
		}

		GUI.Label(new Rect (Screen.width/10 + deltaXGUIComponent, 0, Screen.width * 8 / 10, Screen.height/10), "Construction Games");


		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("10 - shape");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100 + Screen.height/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
			          texts.getText(Quotes.MachineOperator));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height/10, Screen.height/10, Screen.height/10), friends[4]);


		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height*2/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("11 - Robot");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100+Screen.height*2/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
		          texts.getText(Quotes.MaterialOperator));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height*2/10, Screen.height/10, Screen.height/10), friends[3]);


		
		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height*3/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("12 - Puzzle");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100 + Screen.height*3/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
		          texts.getText(Quotes.SheetMetalWorker));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height*3/10, Screen.height/10, Screen.height/10), friends[0]);


		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height*4/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("13 - Control");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100 + Screen.height*4/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
		          texts.getText(Quotes.AirController));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height*4/10, Screen.height/10, Screen.height/10), friends[1]);


		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height*5/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("14 - Paint");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100 + Screen.height*5/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
		          texts.getText(Quotes.AircraftPainter));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height*5/10, Screen.height/10, Screen.height/10), friends[2]);


		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height*6/10, Screen.width * 8 / 10, Screen.height/10), "", m_MyStyle)) {
			Application.LoadLevel ("14 - Paint 2");
		}
		GUI.Label(new Rect (Screen.width * 3 / 20 + Screen.height/10 +  deltaXGUIComponent, Screen.height/100 + Screen.height*6/10, Screen.width * 15 / 20 - Screen.height/10, Screen.height/10), 
		          texts.getText(Quotes.AircraftPainter));
		GUI.DrawTexture (new Rect(Screen.width * 3 / 20 + deltaXGUIComponent, Screen.height*6/10, Screen.height/10, Screen.height/10), friends[2]);





		if (difficulty == 1) {
				if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height * 7 / 10, Screen.width * 8 / 10, Screen.height / 10), "", m_MyStyle)) {
						PlayerPrefs.SetInt ("Difficulty", 2);
						difficulty = 2;
				}
				GUI.Label (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height / 100 + Screen.height * 7 / 10, Screen.width * 8 / 10, Screen.height / 10), 
		          texts.getText(Quotes.DifficultyNormal));
		} else {
		if (GUI.Button (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height * 7 / 10, Screen.width * 8 / 10, Screen.height / 10), "", m_MyStyle)) {
			PlayerPrefs.SetInt ("Difficulty", 1);
				difficulty = 1;
		}
		GUI.Label (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.height / 100 + Screen.height * 7 / 10, Screen.width * 8 / 10, Screen.height / 10), 
			       texts.getText(Quotes.DifficultyHard));
		}

	}

	private void drawSettings()
	{
		if (GUI.Button (new Rect (Screen.width * 2 / 10 + deltaXGUIComponent, Screen.height * 7 / 8, Screen.width * 6 / 10, Screen.height / 10), "Back")) {
			if (state == StateSettings)
				state = StateSettingsToMain;
		}
		GUI.Label(new Rect (Screen.width/10 + deltaXGUIComponent, 0, Screen.width * 8 / 10, Screen.height/10), "Options");
		Texture2D oldBackground = GUI.skin.box.normal.background;
		Texture2D oldBackgroundHover = GUI.skin.box.hover.background; 
		
		GUI.skin.box.normal.background = backgroundSettings;
		GUI.skin.box.hover.background = backgroundSettings;
		GUI.Box(new Rect (Screen.width/40 + deltaXGUIComponent, Screen.height / 10, Screen.width * 19 / 20, Screen.height *15 / 20), 
		        texts.getText(Quotes.Settings));
		GUI.skin.box.normal.background = oldBackground;
		GUI.skin.box.hover.background = oldBackgroundHover;
		GUI.DrawTexture (new Rect(Screen.width*2/10 + deltaXGUIComponent, Screen.height*8/10 - Screen.width*2/10, Screen.width*2/10, Screen.width*2/10), seventh);
		GUI.DrawTexture (new Rect(Screen.width*6/10 + deltaXGUIComponent, Screen.height*8/10 - Screen.width*2/10, Screen.width*2/10, Screen.width*2/10), ics);
	}

	private void drawStats()
	{
		if (GUI.Button (new Rect (Screen.width * 2 / 10 + deltaXGUIComponent, Screen.height * 7 / 8, Screen.width * 6 / 10, Screen.height / 10), "Back")) {
			if (state == StateStats)
				state = StateStatsToMain;
		}
		GUI.Box (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.width / 10, Screen.width * 8 / 10, Screen.height * 6 / 8), "", m_MyStyle);
		GUI.Label(new Rect (Screen.width/9 + deltaXGUIComponent, 0, Screen.width*8/10, Screen.height*8/10), 
		          "<i>Puzzle</i> \n" +
		          "\tMoves : " + PlayerPrefs.GetInt("TaquinMoves") + "\n" + 
		          "\tWins : " + PlayerPrefs.GetInt("TaquinWin"));
	}

	private void drawAchievement()
	{
		if (GUI.Button (new Rect (Screen.width * 2 / 10 + deltaXGUIComponent, Screen.height * 7 / 8, Screen.width * 6 / 10, Screen.height / 10), "Back")) {
			if (state == StateAchievements)
				state = StateAchievementsToMain;
		}
		GUI.Label(new Rect (Screen.width/10 + deltaXGUIComponent, 0, Screen.width * 8 / 10, Screen.height/10), "Achievement");
		if (PlayerPrefs.GetInt ("Achiev_FHP") == 1) {
						GUI.DrawTexture (new Rect (Screen.width / 20 + deltaXGUIComponent, Screen.height / 10, Screen.height / 10, Screen.height / 10), achievements [0]);
						GUI.TextArea (new Rect (Screen.width / 10 + Screen.height / 10 + deltaXGUIComponent, Screen.height / 100 + Screen.height / 10, Screen.width * 17 / 20 - Screen.height / 10, Screen.height / 10), 
		             "You successfully built the FLy Higher plane! \n");
				}
		else{
			GUI.DrawTexture (new Rect (Screen.width / 20 + deltaXGUIComponent, Screen.height / 10, Screen.height / 10, Screen.height / 10), achievements [1]);
			GUI.TextArea (new Rect (Screen.width / 10 + Screen.height / 10 + deltaXGUIComponent, Screen.height / 100 + Screen.height / 10, Screen.width * 8 / 10 - Screen.height / 10, Screen.height / 10), 
			              "Construct the Fly Higher Plane to unlock this achievement. \n");
		}
	}
	
	
	private void drawConstruct()
	{
		Application.LoadLevel ("hangar stape 1");

		if (GUI.Button (new Rect (Screen.width * 2 / 10 + deltaXGUIComponent, Screen.height * 7 / 8, Screen.width * 6 / 10, Screen.height / 10), "Back")) {
				if (state == StateConstruct)
						state = StateConstructToMain;
		}
		GUI.Box (new Rect (Screen.width / 10 + deltaXGUIComponent, Screen.width / 10, Screen.width * 8 / 10, Screen.height * 6 / 8), "", m_MyStyle);
		GUI.Label (new Rect (Screen.width / 9 + deltaXGUIComponent, Screen.height / 5, Screen.width * 8 / 10, Screen.height * 8 / 10), 
  			"Build \n" +
				"Not Yet Implemented");
	}
}