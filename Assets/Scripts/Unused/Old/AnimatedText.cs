using UnityEngine;
using System.Collections;

public class AnimatedText : MonoBehaviour {
	
	public string mText = "Hello Word";
	public float timeAnime = 0.5f;
	public float timeWait = 5;
	
	Rect currentRect;
	Rect targetRect;
	float dateDepard;
	public Texture2D background;
	
	// Use this for initialization
	void Start () {
		mText = getQuote ();
		targetRect = new Rect (Screen.width/8, Screen.height/2-50, Screen.width*6/8, Screen.height/4 );
		currentRect = new Rect (-Screen.width, Screen.height/2-50, Screen.width*6/8, Screen.height/4 );
		dateDepard = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float avance = Time.time - dateDepard;
		
		if (avance < timeAnime) 
		{//pop in
			//currentRect = avance*targetRect/timeAnime;
			currentRect.x = avance*targetRect.x/timeAnime;
		} 
		else if (avance < timeWait + timeAnime) 
		{//Not moove -> reading
			currentRect = targetRect;	
		} 
		else if (avance < timeWait + 2 * timeAnime) 
		{//pop out
			targetRect = new Rect (Screen.width/2 * 3, Screen.height/2-50, Screen.width/2, 100 );
			float avanceB = avance - (timeWait + timeAnime);
			currentRect.x = avanceB*targetRect.x/timeAnime + Screen.width/4;
		} else 
		{//end
			Destroy(gameObject);
		}
		
	}
	
	void OnGUI()
	{
		GUI.skin = MySkin.getSkin();
		//GUI.skin.textArea.
		GUI.backgroundColor = MySkin.getColor();

		Texture2D oldBackground = GUI.skin.box.normal.background;

		GUI.skin.box.normal.background = background;
		GUI.Box ( currentRect, mText );
		GUI.skin.box.normal.background = oldBackground;
	}
	
	string getQuote()
	{
		int language = 0;
		if (Application.systemLanguage == SystemLanguage.French)
			language = 1;
		if (Application.systemLanguage == SystemLanguage.German)
			language = 2;
		if (Application.systemLanguage == SystemLanguage.Portuguese)
			language = 3;
		int res = Random.Range (0, 20);
		//anglais
		if (language == 0) {
			switch (res) {
			case 1:
				return("Un avion décolle toutes les secondes environ dans le monde.");
			case 2:
				return("Il y a 500 000 personnes dans le ciel à chaque instant.");
			case 3:
				return("Le premier avion (Eole) ressemblait à une chauve-souris.");
			case 4:
				return("L’air est invisible mais il a un poids.");
			case 5:
				return("L’air chaud est plus léger que l’air.");
			case 6:
				return("Les montgolfières s’envolent grâce à l’air chaud.");
			case 7:
				return("Les montgolfières ont été les premières machines volantes.");
			case 8:
				return("Les passagers du premier vol en montgolfière étaient un coq, un mouton et un canard.");
			case 9:
				return("Pour voler l’avion a besoin de portance et de poussée.");
			case 10:
				return("C’est l’écoulement de l’air autour des ailes qui créé la portance.");
			case 11:
				return("C’est le moteur qui fournit la poussée.");
			case 12:
				return("Les gouvernes permettent de déplacer l’avion en vol.");
			case 13:
				return("La forme des ailes des avions ont été inspirées par les ailes des oiseaux.");
			case 14:
				return("La partie supérieure de l’aile est plus volumineuse que la partie inférieure.");
			case 15:
				return("La portance est créée par le profil de l’aile.");
			case 16:
				return("Un biplan est un avion dont les ailes sont sur deux plans parallèles et reliés.");
			case 17:
				return("Un aéronef désigne tout appareil permettant de s’élever ou de se diriger dans les airs.");
			case 18:
				return("Le vol est constitué de trois étapes : le décollage, le vol de croisière et l’atterrissage.");
			case 19:
				return("L’avion est le moyen de transport en commun le plus rapide.");
			default :
				return("Fly Higher est un projet européen pour apprendre l'aéronotique aux enfants!");
				
			}
		} else if (language == 1) {
			switch (res) {
			case 1:
				return("Un avion décolle toutes les secondes environ dans le monde.");
			case 2:
				return("Il y a 500 000 personnes dans le ciel à chaque instant.");
			case 3:
				return("Le premier avion (Eole) ressemblait à une chauve-souris.");
			case 4:
				return("L’air est invisible mais il a un poids.");
			case 5:
				return("L’air chaud est plus léger que l’air.");
			case 6:
				return("Les montgolfières s’envolent grâce à l’air chaud.");
			case 7:
				return("Les montgolfières ont été les premières machines volantes.");
			case 8:
				return("Les passagers du premier vol en montgolfière étaient un coq, un mouton et un canard.");
			case 9:
				return("Pour voler l’avion a besoin de portance et de poussée.");
			case 10:
				return("C’est l’écoulement de l’air autour des ailes qui créé la portance.");
			case 11:
				return("C’est le moteur qui fournit la poussée.");
			case 12:
				return("Les gouvernes permettent de déplacer l’avion en vol.");
			case 13:
				return("La forme des ailes des avions ont été inspirées par les ailes des oiseaux.");
			case 14:
				return("La partie supérieure de l’aile est plus volumineuse que la partie inférieure.");
			case 15:
				return("La portance est créée par le profil de l’aile.");
			case 16:
				return("Un biplan est un avion dont les ailes sont sur deux plans parallèles et reliés.");
			case 17:
				return("Un aéronef désigne tout appareil permettant de s’élever ou de se diriger dans les airs.");
			case 18:
				return("Le vol est constitué de trois étapes : le décollage, le vol de croisière et l’atterrissage.");
			case 19:
				return("L’avion est le moyen de transport en commun le plus rapide.");
			default :
				return("Fly Higher est un projet européen pour apprendre l'aéronotique aux enfants!");
				
			}
		}
		return ("Fly Higher is a European Project!");
	}
}
