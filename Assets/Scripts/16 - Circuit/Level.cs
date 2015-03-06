using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Level : MonoBehaviour {


	public void LevelLoader(int levelNb){
		GameObject station = GetComponent<BoardManager> ().station;
		switch (levelNb) {
		case 1: Level1 (gameObject, station); break;
		case 2: Level2 (gameObject, station); break;
		case 3: Level3 (gameObject, station); break;
		case 4: Level4 (gameObject, station); break;
		case 5: Level5 (gameObject, station); break;
		case 6: Level6 (gameObject, station); break;
		default: Level1 (gameObject, station); break;
		}
	}

	private void Level1(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (3);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 0, 0, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 1, 1, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 1, 0, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 0, 2, Station.StationColor.BLACK);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		bm.SetEnsembles(ensembles);
	}

	private void Level2(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (4);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 0, 0, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 2, 1, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 1, 0, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 0, 2, Station.StationColor.BLACK);
		GameObject blueS1 = CreateStation (board, station, 0, 3, Station.StationColor.BLUE);
		GameObject blueS2 = CreateStation (board, station, 3, 3, Station.StationColor.BLUE);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		Ensemble e3 = new Ensemble (board, blueS1, blueS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		ensembles.Add (e3);
		bm.SetEnsembles(ensembles);
	}

	private void Level3(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (4);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 1, 0, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 0, 3, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 2, 0, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 2, 2, Station.StationColor.BLACK);
		GameObject blueS1 = CreateStation (board, station, 2, 1, Station.StationColor.BLUE);
		GameObject blueS2 = CreateStation (board, station, 2, 3, Station.StationColor.BLUE);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		Ensemble e3 = new Ensemble (board, blueS1, blueS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		ensembles.Add (e3);
		bm.SetEnsembles(ensembles);
	}

	private void Level4(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 2, 0, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 3, 1, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 3, 0, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 4, 4, Station.StationColor.BLACK);
		GameObject blueS1 = CreateStation (board, station, 1, 1, Station.StationColor.BLUE);
		GameObject blueS2 = CreateStation (board, station, 2, 3, Station.StationColor.BLUE);
		GameObject redS1 = CreateStation (board, station, 1, 2, Station.StationColor.RED);
		GameObject redS2 = CreateStation (board, station, 0, 4, Station.StationColor.RED);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		Ensemble e3 = new Ensemble (board, blueS1, blueS2);
		Ensemble e4 = new Ensemble (board, redS1, redS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		ensembles.Add (e3);
		ensembles.Add (e4);
		bm.SetEnsembles(ensembles);
	}

	private void Level5(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 0, 0, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 4, 4, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 0, 2, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 2, 2, Station.StationColor.BLACK);
		GameObject blueS1 = CreateStation (board, station, 1, 2, Station.StationColor.BLUE);
		GameObject blueS2 = CreateStation (board, station, 3, 2, Station.StationColor.BLUE);
		GameObject redS1 = CreateStation (board, station, 3, 3, Station.StationColor.RED);
		GameObject redS2 = CreateStation (board, station, 0, 4, Station.StationColor.RED);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		Ensemble e3 = new Ensemble (board, blueS1, blueS2);
		Ensemble e4 = new Ensemble (board, redS1, redS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		ensembles.Add (e3);
		ensembles.Add (e4);
		bm.SetEnsembles(ensembles);
	}

	private void Level6(GameObject board, GameObject station){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		bm.GenerateBoard ();
		List <Ensemble> ensembles = new List<Ensemble> ();
		GameObject whiteS1 = CreateStation (board, station, 0, 1, Station.StationColor.WHITE);
		GameObject whiteS2 = CreateStation (board, station, 4, 1, Station.StationColor.WHITE);
		GameObject blackS1 = CreateStation (board, station, 1, 1, Station.StationColor.BLACK);
		GameObject blackS2 = CreateStation (board, station, 3, 3, Station.StationColor.BLACK);
		GameObject blueS1 = CreateStation (board, station, 1, 3, Station.StationColor.BLUE);
		GameObject blueS2 = CreateStation (board, station, 3, 1, Station.StationColor.BLUE);
		GameObject redS1 = CreateStation (board, station, 3, 2, Station.StationColor.RED);
		GameObject redS2 = CreateStation (board, station, 4, 4, Station.StationColor.RED);
		Ensemble e1 = new Ensemble (board, whiteS1, whiteS2);
		Ensemble e2 = new Ensemble (board, blackS1, blackS2);
		Ensemble e3 = new Ensemble (board, blueS1, blueS2);
		Ensemble e4 = new Ensemble (board, redS1, redS2);
		ensembles.Add (e1);
		ensembles.Add (e2);
		ensembles.Add (e3);
		ensembles.Add (e4);
		bm.SetEnsembles(ensembles);
	}

	private GameObject CreateStation (GameObject board, GameObject station, int x, int y, Station.StationColor sc){
		GameObject instance = Instantiate (station) as GameObject;
		Station s = instance.GetComponent<Station>();
		s.Init (board, x, y, sc);
		s.Draw ();
		return instance;
	}

}
