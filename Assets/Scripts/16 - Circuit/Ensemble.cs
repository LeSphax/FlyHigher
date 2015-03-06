using UnityEngine;
using System.Collections;

public class Ensemble : MonoBehaviour {

	[HideInInspector] public GameObject board;
	[HideInInspector] public GameObject station1;
	[HideInInspector] public GameObject station2;
	[HideInInspector] public Path path;
	[HideInInspector] public bool binded;

	public Ensemble(GameObject board, GameObject s1, GameObject s2){
		this.board = board;
		station1 = s1;
		station2 = s2;
		binded = false;
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

	public void Left(){
		MoveAction (PathPiece.Direction.LEFT);
	}

	private void MoveAction (PathPiece.Direction d){
		bool wasLastPart = false;
		if (path.isMovePossible(d)) wasLastPart = path.AddPathPiece (d);
		else {
			//TODO play animation
		}
	}

	public void ReverseStations(){
		GameObject temp = station1;
		station1 = station2;
		station2 = temp;
	}
}
