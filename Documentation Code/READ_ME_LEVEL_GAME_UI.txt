--------------------------------------------------------------------------------
Partie I : Mise En Place
--------------------------------------------------------------------------------

step 1 mettre le prefab LevelGameUI dans la scene

step 2 LevelGameUI -> LevelChooser : Al (voir Partie II : Abstract Level)

step 3 LevelGameUI -> LevelChooser : Star [i]Level Nb choisissez le nombre de 
	niveau voulu pour chaque étoile

step 4 LevelGameUI -> LevelChooser -> Background : sourceImage L'image que vous 
	voulez comme fond de votre lvlChooser




--------------------------------------------------------------------------------
Partie II : Abstract Level
--------------------------------------------------------------------------------

Vous devez coder votre MiniGameLevel sous le format définit dans Abstract Level

avec 2 fonctions public void :
	-> LoadLevel(int lvlNb);
		Cette fonction va être appeller quand l'utilisateur va cliquer
		Sur le bouton n°lvlNb
	-> Clear()
		Cette fonction va être appeller quand l'utilisateur va cliquer
		sur le bouton restart à la fin du niveau*


*le bouton restart appelera la fonction clear(); puis la fonction 
LoadLevel(int lvlNb); 





--------------------------------------------------------------------------------
Partie III : Infos Importante
--------------------------------------------------------------------------------

1°) Quand votre niveau est fini appeler la methode LevelEnded() du script 
EndLevelPopUp se trouvant sur le gameObject GameUI (LevelGameUI -> GameUI)

2°) Quand l'utilisateur appuie sur le bouton retour au menu de selection des
niveaux je recharge la scene donc pas besoin de nettoyer votre niveau;

3°) Placer le prefab le plus bas possible dans la hierarchie





--------------------------------------------------------------------------------