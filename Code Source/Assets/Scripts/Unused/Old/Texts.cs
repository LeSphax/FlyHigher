using UnityEngine;
using System.Collections;

public enum Quotes 
{
	//Menu
	play,
	build,
	back,
	finish,
	MachineOperator,
	MaterialOperator,
	SheetMetalWorker,
	AirController,
	AircraftPainter,
	Settings,
	DifficultyHard,
	DifficultyNormal,
	DifficultyHardShort,
	DifficultyNormalShort,
	Speak,
	Help,
	//Build
	BuildDiag0,
	BuildDiag1,
	BuildDiag2,
	BuildDiag3,
	BuildDiag4,
	BuildDiag5,
	BuildDiag6,
	//10 - Shape
	Game10Diag1,
	Game10Diag2,
	Game10Diag3,
	Game10Diag4,
	//11 - Shape
	Game11Diag1,
	Game11Diag2,
	Game11Diag31,
	Game11Diag32,
	Game11Diag4,
	//12 - Shape
	Game12Diag1,
	Game12Diag2,
	Game12Diag3,
	Game12Diag4,
	//13 - Robot
	Game13Diag1,
	Game13Diag2,
	Game13Diag3,
	Game13Diag4,
	//14 - Paint2
	Game14Diag1,
	Game14Diag2,
	Game14Diag3,
	Game14Diag4,
	//14 - Paint2
	Game142Diag1,
	Game142Diag2,
	Game142Diag3,
	Game142Diag4

};

public class Texts {
	static int language;
	private string[] texts;
	//The size of Quotes
	private int nbQuotes = System.Enum.GetNames(typeof(Quotes)).Length;
	//private int nbQuotes = 6;


	// Use this for initialization
	public Texts () {
		//Default language = English
		language = 0;
		if (Application.systemLanguage == SystemLanguage.French)
						language = 1;
		//if (Application.systemLanguage == SystemLanguage.German)
		//	language = 2;
		//if (Application.systemLanguage == SystemLanguage.Portuguese)
		//	language = 3;
		initTexts ();
	}
	
	public string getText(Quotes id)
	{
		return texts [(int)id];
	}

	private void initTexts(){
		texts = new string[nbQuotes];
		if (language == 0) {
				//English
			//menu
			texts [(int)Quotes.play] = "Play";
			texts [(int)Quotes.build] = "Build";
			texts [(int)Quotes.back] = "Back";
			texts [(int)Quotes.finish] = "Finish";
			texts [(int)Quotes.MachineOperator] = "Machine Operator";
			texts [(int)Quotes.MaterialOperator] = "Material Operator";
			texts [(int)Quotes.SheetMetalWorker] = "Sheet-Metal Worker";
			texts [(int)Quotes.AirController] = "Air Traffic Controller";
			texts [(int)Quotes.AircraftPainter] = "Aircraft Painter";
			texts [(int)Quotes.Settings] = "\t Fly Higher is a European project.\n" + 
				"\t For further information about the Fly Higher Project, please visit our website on www.flyhigher.eu\n\n" +
					"\t ICS members : Philippe Palanque, Célia Martinie\n\n" +
					"\t Created by Damien Ablart\n\n" +
					"\t Special Thanks to Raphael Guenon\n";
			texts [(int)Quotes.DifficultyHard] = "Difficulty: Hard";
			texts [(int)Quotes.DifficultyNormal] = "Difficulty: Normal";
			texts [(int)Quotes.DifficultyHardShort] = "Hard";
			texts [(int)Quotes.DifficultyNormalShort] = "Normal";
			texts [(int)Quotes.Speak] = "Speak";
			texts [(int)Quotes.Help] = "Help";
			//buildDiag
			texts [(int)Quotes.BuildDiag0] = "Hi! I am the material operator! Would you like to help me to cut a piece?";
			texts [(int)Quotes.BuildDiag1] = "Hi! I am the machine operator! Would you like to help me to calibrate the machine?";
			texts [(int)Quotes.BuildDiag2] = "Hi! I am the sheet-metal Worker! Would you like help me to assemble the aircraft?";
			texts [(int)Quotes.BuildDiag3] = "Hi! I am the air traffic controller! Would you like help me with the first fly?";
			texts [(int)Quotes.BuildDiag4] = "Hi! I am the aircraft painter! Would you like help me to create the painting?";
			texts [(int)Quotes.BuildDiag5] = "Hi! I am the aircraft painter! Would you like to help me with painting the aircraft?";
			texts [(int)Quotes.BuildDiag6] = "Well done! You have built the Fly Higher plane! Do you want to help me with building another one?";
			//10 - Shape
			texts [(int)Quotes.Game10Diag1] = "Swipe your finger on the screen to connect the points!";
			texts [(int)Quotes.Game10Diag2] = "Yes, like that! Connect them all!";
			texts [(int)Quotes.Game10Diag3] = "Quote3";
			texts [(int)Quotes.Game10Diag4] = "Great! You have cut the piece!";
			//11 - Robot
			texts [(int)Quotes.Game11Diag1] = "Push the arrows to move the cursor!";
			texts [(int)Quotes.Game11Diag2] = "Target the spot and push the green button!";
			texts [(int)Quotes.Game11Diag31] = "Yay! ";
			texts [(int)Quotes.Game11Diag32] = " to go!";
			texts [(int)Quotes.Game11Diag4] = "Yaaay! You did it! Well done!";
			//12 - Puzzle
			texts [(int)Quotes.Game12Diag1] = "Move the tiles by sliding your finger on the screen!";
			texts [(int)Quotes.Game12Diag2] = "Yay! Try to solve the puzzle!";
			texts [(int)Quotes.Game12Diag3] = "Almost done!";
			texts [(int)Quotes.Game12Diag4] = "Yaaay! You did it! Well done!";
			//13 - Control
			texts [(int)Quotes.Game13Diag1] = "Push arrows to change the direction of the plane!";
			texts [(int)Quotes.Game13Diag2] = "Yay! Try to visit all points!";
			texts [(int)Quotes.Game13Diag3] = "One more and it's over!";
			texts [(int)Quotes.Game13Diag4] = "Yaaay! You did it! Well done!"; 
			//14 - Paint2
			texts [(int)Quotes.Game14Diag1] = "Touch a pot of paint to change the color!";
			texts [(int)Quotes.Game14Diag2] = "Yay! Try get the right color!";
			texts [(int)Quotes.Game14Diag3] = "Almost done!";
			texts [(int)Quotes.Game14Diag4] = "Yaaay! You did it! Well done!";
			//14 - Paint2
			texts [(int)Quotes.Game142Diag1] = "Select the color on the right!";
			texts [(int)Quotes.Game142Diag2] = "Color the right tile with the right color!!";
			texts [(int)Quotes.Game142Diag3] = "Almost done!";
			texts [(int)Quotes.Game142Diag4] = "Yaaay! You did it! Well done!";
		} else if (language == 1) {
			//French
			//menu
			texts [(int)Quotes.play] = "Jouer";
			texts [(int)Quotes.build] = "Hangar";
			texts [(int)Quotes.back] = "Retour";
			texts [(int)Quotes.finish] = "Finir";
			texts [(int)Quotes.MachineOperator] = "Opérateur sur matériaux";
			texts [(int)Quotes.MaterialOperator] = "Opérateur sur machines";
			texts [(int)Quotes.SheetMetalWorker] = "Chaudronnier";
			texts [(int)Quotes.AirController] = "Contrôleur aérien";
			texts [(int)Quotes.AircraftPainter] = "Peintre aéronautique";
			texts [(int)Quotes.Settings] = "\t Fly Higher est un projet européen.\n" + 
				"\t Pour plus d'informations sur le projet Fly Higher, veuillez visiter le site www.flyhigher.eu\n\n" +
					"\t Membres ICS : Philippe Palanque, Célia Martinie\n\n" +
					"\t Créé par Damien Ablart\n\n" +
					"\t Remerciements:  Raphael Guenon\n";
			texts [(int)Quotes.DifficultyHard] = "Difficulté: Dur";
			texts [(int)Quotes.DifficultyNormal] = "Difficulté: Normal";
			texts [(int)Quotes.DifficultyHardShort] = "Diffficile";
			texts [(int)Quotes.DifficultyNormalShort] = "Normal";
			texts [(int)Quotes.Speak] = "Parler";
			texts [(int)Quotes.Help] = "Aider";
			//Build
			texts [(int)Quotes.BuildDiag0] = "Salut! Je suis l'opérateur sur matériaux composites! Veux-tu m'aider à découper une pièce?";
			texts [(int)Quotes.BuildDiag1] = "Salut! Je suis l'opérateur sur machine à commande numérique! Veux-tu m'aider à régler la machine?";
			texts [(int)Quotes.BuildDiag2] = "Salut! Je suis le chaudronnier! Veux-tu m'aider à assembler l'avion?";
			texts [(int)Quotes.BuildDiag3] = "Salut! Je suis le contrôleur aérien! Veux-tu m'aider à faire le premier vol de test?";
			texts [(int)Quotes.BuildDiag4] = "Salut! Je suis le peintre aéronautique! Veux-tu m'aider à faire le mélange de peintures?";
			texts [(int)Quotes.BuildDiag5] = "Salut! Je suis le peintre aéronautique! Veux-tu m'aider à peindre l'avion?";
			texts [(int)Quotes.BuildDiag6] = "Super! Tu as construit l'avion Fly Higher! Veux-tu m'aider à en construire un autre?";
			//10 - Shape
			texts [(int)Quotes.Game10Diag1] = "Glisse ton doigt sur l'écran pour relier les points!";
			texts [(int)Quotes.Game10Diag2] = "Oui comme ça! Relie les tous!";
			texts [(int)Quotes.Game10Diag3] = "-";
			texts [(int)Quotes.Game10Diag4] = "Super! Tu as découpé la pièce!";
			//11 - Robot
			texts [(int)Quotes.Game11Diag1] = "Appuie sur les flèches pour bouger le curseur!";
			texts [(int)Quotes.Game11Diag2] = "Vise un point et appuie sur le bouton!";
			texts [(int)Quotes.Game11Diag31] = "Yay! Plus que ";
			texts [(int)Quotes.Game11Diag32] = " !";
			texts [(int)Quotes.Game11Diag4] = "Yaay! Tu as réussi! Bien joué!";
			//12 - Puzzle
			texts [(int)Quotes.Game12Diag1] = "Bouge les pièces en glissant ton doigt sur l'écran.";
			texts [(int)Quotes.Game12Diag2] = "Yay! Essaie de remettre les pièces dans l'ordre!";
			texts [(int)Quotes.Game12Diag3] = "Yay! ";
			texts [(int)Quotes.Game12Diag4] = "Yaaay! Tu l'as remis dans l'ordre! Bien joué!";
			//13 - Robot
			texts [(int)Quotes.Game13Diag1] = "Appuie sur les flèches pour changer la direction de l'avion!";
			texts [(int)Quotes.Game13Diag2] = "Yay! Visite tous les points!";
			texts [(int)Quotes.Game13Diag3] = "Plus qu'un et c'est fini!";
			texts [(int)Quotes.Game13Diag4] = "Yaaay! Tu les as eu! Bien joué!"; 
			//14 - Paint2
			texts [(int)Quotes.Game14Diag1] = "Touche un pot de peinture pour changer la couleur!";
			texts [(int)Quotes.Game14Diag2] = "Yay! Essaie de colorier de la bonne couleur!";
			texts [(int)Quotes.Game14Diag3] = "Tu y es presque!";
			texts [(int)Quotes.Game14Diag4] = "Yaaay! Tu as réussi! Bien joué!";
			//14 - Paint2
			texts [(int)Quotes.Game142Diag1] = "Sélectionne la couleur avec les pots à droite!";
			texts [(int)Quotes.Game142Diag2] = "Colorie les cases avec les bonnes couleurs!!";
			texts [(int)Quotes.Game142Diag3] = "Tu y es presque!";
			texts [(int)Quotes.Game142Diag4] = "Yaaay! Tu as réussi! Bien joué!";
		}
	}
}
