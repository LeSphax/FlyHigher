using UnityEngine;
using System.Collections;

public class Ensemble : MonoBehaviour {

	/*public GameObject station;

	[HideInInspector] public GameObject board;
	[HideInInspector] public GameObject station1;
	[HideInInspector] public GameObject station2;
	[HideInInspector] public Path path;
	[HideInInspector] public bool binded;

	public Ensemble(GameObject board, Coordinate c1, Coordinate c2, Station.StationColor sc){
		this.board = board;
		station1 = CreateStation (c1, sc);
		station2 = CreateStation (c2, sc);
		binded = false;
	}

	private GameObject CreateStation(Coordinate c, Station.StationColor sc){
		GameObject instance = Instantiate (station) as GameObject;
		Station s = instance.GetComponent<Station> ();
		s.Init (board, this, c, sc);
		s.Draw ();
		return instance;
	}

	public void InitPath(GameObject selectedStation){
		Coordinate s1c = station1.GetComponent<Station> ().coordinate;
		Coordinate s2c = station2.GetComponent<Station> ().coordinate;
		Coordinate c = selectedStation.GetComponent<Station> ().coordinate;
		if (c == s2c) {
			ReverseStations();
		}
		Station source = station1.GetComponent<Station> ();
		Station target = station2.GetComponent<Station> ();
		source.isSelected = true;
		path = new Path (board, source.coordinate, target.coordinate);
	}

	public void MoveAction (PathPiece.Direction d){
		bool wasLastPart = false;
		if (path.isMovePossible (d))
			wasLastPart = path.AddPathPiece (d);
		else {
			//TODO play animation
		}
		if (wasLastPart) {
			Station s1 = station1.GetComponent<Station>();
			s1.isSelected = false;
			s1.Draw();
			binded = true;
		}
	}

	public void ReverseStations(){
		GameObject temp = station1;
		station1 = station2;
		station2 = temp;
	}*/
}
