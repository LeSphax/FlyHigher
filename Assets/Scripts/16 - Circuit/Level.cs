using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Level : MonoBehaviour {


	public void LevelLoader(int levelNb){
		switch (levelNb) {
		case 1: Level1 (gameObject); break;
		case 2: Level2 (gameObject); break;
		case 3: Level3 (gameObject); break;
		case 4: Level4 (gameObject); break;
		case 5: Level5 (gameObject); break;
		case 6: Level6 (gameObject); break;
		default: Level1 (gameObject); break;
		}
	}


	private GameObject CreateStation(BoardManager bm, Coordinate c, Station.StationColor sc){
		GameObject instance = Instantiate (bm.station) as GameObject;
		Station station = instance.GetComponent<Station> ();
		station.Init (bm.gameObject, c, sc);
		station.Draw ();
		return instance;
	}

	private void Level1(GameObject board){
		BoardManager bm = GetComponent<BoardManager> ();
		bm.Init (3);
		GameObject s1 = CreateStation (bm, new Coordinate (0, 0), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (1, 1), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (1, 0), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (0, 2), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		/*bm.freeCoordinates.Remove(s1.GetComponent<Station>().coordinate);
		bm.freeCoordinates.Remove(s2.GetComponent<Station>().coordinate);
		bm.freeCoordinates.Remove(s3.GetComponent<Station>().coordinate);
		bm.freeCoordinates.Remove(s4.GetComponent<Station>().coordinate);*/
	}

	private void Level2(GameObject board){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (4);
		GameObject s1 = CreateStation (bm, new Coordinate(0, 0), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (2, 1), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (1, 0), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (0, 2), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		GameObject s5 = CreateStation (bm, new Coordinate (0, 3), Station.StationColor.BLUE);
		GameObject s6 = CreateStation (bm, new Coordinate (3, 3), Station.StationColor.BLUE);
		s5.GetComponent<Station> ().brotherStation = s6;
		s6.GetComponent<Station> ().brotherStation = s5;
	}

	private void Level3(GameObject board){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (4);
		GameObject s1 = CreateStation (bm, new Coordinate (1, 0), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (0, 3), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (2, 0), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (2, 2), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		GameObject s5 = CreateStation (bm, new Coordinate (2, 1), Station.StationColor.BLUE);
		GameObject s6 = CreateStation (bm, new Coordinate (2, 3), Station.StationColor.BLUE);
		s5.GetComponent<Station> ().brotherStation = s6;
		s6.GetComponent<Station> ().brotherStation = s5;
	}

	private void Level4(GameObject board){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		GameObject s1 = CreateStation (bm,  new Coordinate (2, 0), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (3, 1), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (3, 0), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (4, 4), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		GameObject s5 = CreateStation (bm, new Coordinate (1, 1), Station.StationColor.BLUE);
		GameObject s6 = CreateStation (bm, new Coordinate (2, 3), Station.StationColor.BLUE);
		s5.GetComponent<Station> ().brotherStation = s6;
		s6.GetComponent<Station> ().brotherStation = s5;
		GameObject s7 = CreateStation (bm, new Coordinate (1, 2), Station.StationColor.RED);
		GameObject s8 = CreateStation (bm, new Coordinate (0, 4), Station.StationColor.RED);
		s7.GetComponent<Station> ().brotherStation = s8;
		s8.GetComponent<Station> ().brotherStation = s7;
	}

	private void Level5(GameObject board){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		GameObject s1 = CreateStation (bm, new Coordinate (0, 0), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (4, 4), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (0, 2), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (2, 2), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		GameObject s5 = CreateStation (bm, new Coordinate (1, 2), Station.StationColor.BLUE);
		GameObject s6 = CreateStation (bm, new Coordinate (3, 2), Station.StationColor.BLUE);
		s5.GetComponent<Station> ().brotherStation = s6;
		s6.GetComponent<Station> ().brotherStation = s5;
		GameObject s7 = CreateStation (bm, new Coordinate (3, 3), Station.StationColor.RED);
		GameObject s8 = CreateStation (bm, new Coordinate (0, 4), Station.StationColor.RED);
		s7.GetComponent<Station> ().brotherStation = s8;
		s8.GetComponent<Station> ().brotherStation = s7;
	}

	private void Level6(GameObject board){
		BoardManager bm = board.GetComponent<BoardManager> ();
		bm.Init (5);
		GameObject s1 = CreateStation (bm, new Coordinate (0, 1), Station.StationColor.WHITE);
		GameObject s2 = CreateStation (bm, new Coordinate (4, 1), Station.StationColor.WHITE);
		s1.GetComponent<Station> ().brotherStation = s2;
		s2.GetComponent<Station> ().brotherStation = s1;
		GameObject s3 = CreateStation (bm, new Coordinate (1, 1), Station.StationColor.BLACK);
		GameObject s4 = CreateStation (bm, new Coordinate (3, 3), Station.StationColor.BLACK);
		s3.GetComponent<Station> ().brotherStation = s4;
		s4.GetComponent<Station> ().brotherStation = s3;
		GameObject s5 = CreateStation (bm, new Coordinate (1, 3), Station.StationColor.BLUE);
		GameObject s6 = CreateStation (bm, new Coordinate (3, 1), Station.StationColor.BLUE);
		s5.GetComponent<Station> ().brotherStation = s6;
		s6.GetComponent<Station> ().brotherStation = s5;
		GameObject s7 = CreateStation (bm, new Coordinate (3, 2), Station.StationColor.RED);
		GameObject s8 = CreateStation (bm, new Coordinate (4, 4), Station.StationColor.RED);
		s7.GetComponent<Station> ().brotherStation = s8;
		s8.GetComponent<Station> ().brotherStation = s7;
	}
}
