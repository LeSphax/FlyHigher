using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public enum State {Begin, StationPressed, End}

	public GameObject boardPiece;
	public GameObject station;
	public GameObject path;
	public GameObject gameController;
	//public GameObject gameManager;

	public Button cancelButton;
	public Button restartButton;

	public State state;

	[HideInInspector] public int size;
	[HideInInspector] public float width;
	[HideInInspector] public float height;

	[HideInInspector] public List <Coordinate> freeCoordinates = new List<Coordinate> ();
	[HideInInspector] public List <GameObject> stations = new List <GameObject> ();
	[HideInInspector] public List <GameObject> paths = new List<GameObject> ();

	private List <GameObject> boardPieces = new List <GameObject> ();
	private GameObject selectedStation;

	public void Init(int size){
		this.size = size;
		RectTransform rt = GetComponent<RectTransform> ();
		this.width = rt.sizeDelta.x;
		this.height = rt.sizeDelta.y;
		GenerateBoard ();
		state = State.Begin;
	}

	public void OnMouseExit(){
		OnBoardLeave ();
	}

	private void GenerateBoard (){
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				GameObject instance = Instantiate (boardPiece) as GameObject;
				BoardPiece bp = instance.GetComponent <BoardPiece>();
				bp.Init(gameObject, i, j);
				bp.Draw();
				boardPieces.Add(instance);
				freeCoordinates.Add(new Coordinate(i, j));
			}
		}
	}

	public void OnBoardLeave(){
		/*switch (state) {
		case State.Begin:
			state = State.Begin;
			break;
		case State.StationPressed:
			state = State.Begin;
			SetSelectedStation(false, false);
			DeleteLastPast();
			selectedStation = null;
			break;
		case State.End:
			state = State.End;
			break;
		}*/
	}
	

	public void OnBoardPieceEnter(GameObject boardPiece){
		switch (state) {
		case State.Begin:
			state = State.Begin;
			break;
		case State.StationPressed:
			Element e = boardPiece.GetComponent<Element>();
			Path p = paths[paths.Count - 1].GetComponent<Path>();
			PathPiece.Direction d = GetGoingDirection(e.coordinate);
			if (DistanceEqualToOne(e.coordinate) && p.isMovePossible(d)){
				if (p.AddPathPiece(d)){
					cancelButton.interactable = true;
					restartButton.interactable = true;
					SetSelectedStation(false, true);
					selectedStation = null;
					if (isLevelComplete()){
						cancelButton.interactable = false;
						restartButton.interactable = false;
						state = State.End;
						GameObject.FindWithTag("GamesUI").BroadcastMessage("LevelEnded");
					} else {
						state = State.Begin;
					}
				} else {
					state = State.StationPressed;
				}
			} else {
				state = State.Begin;
				SetSelectedStation(false, false);
				DeleteLastPast();
				selectedStation = null;
			}

			break;
		case State.End:
			state = State.End;
			break;
		}
	}

	public void OnStationPressed(GameObject station){
		switch (state) {
		case State.Begin:
			selectedStation = station;
			if (selectedStation.GetComponent<Station>().isBinded){
				state = State.Begin;
				selectedStation = null;
			} else {
				state = State.StationPressed; 
				SetSelectedStation(true, false);
				GameObject instance = Instantiate (path) as GameObject;
				instance.GetComponent<Path> ().Init(gameObject, selectedStation);
			}
			break;
		case State.StationPressed:
			//IMPOSSIBLE
			Debug.LogError ("IMPOSSIBLE : OnStationPressed : StationPressed");
			break;
		case State.End:
			state = State.End;
			break;
		}
	}

	public void OnBoardReleased(GameObject boardPiece){
		switch (state) {
		case State.Begin:
			state = State.Begin;
			break;
		case State.StationPressed:
			Coordinate c1 = boardPiece.GetComponent<Element>().coordinate;
			Coordinate c2 = selectedStation.GetComponent<Station>().brotherStation.GetComponent<Station>().coordinate;
			if(c1.x != c2.x || c1.y != c2.y){
				state = State.Begin;
				SetSelectedStation(false, false);
				DeleteLastPast();
				selectedStation = null;
			}
			break;
		case State.End:
			state = State.End;
			break;
		}
	}
	
	public void OnCancelButtonCliked(){
		switch (state) {
		case State.Begin:
			state = State.Begin;
			Station s = paths[paths.Count - 1].GetComponent<Path>().source.GetComponent<Station>();
			s.isBinded = false;
			s.brotherStation.GetComponent<Station>().isBinded = false;
			paths[paths.Count - 1].GetComponent<Path>().RemoveAllPath();
			Destroy (paths[paths.Count - 1]);
			paths.Remove (paths[paths.Count - 1]);
			if (paths.Count <= 0) {
				cancelButton.interactable = false;
				restartButton.interactable = false;
			}
			break;
		case State.StationPressed:
			
			break;
		case State.End:
			
			break;
		}
	}

	public void OnResetButtonCliked(){
		switch (state) {
		case State.Begin:
			ResetPaths();
			break;
		case State.StationPressed:
			
			break;
		case State.End:
			
			break;
		}
	}

	private bool DistanceEqualToOne (Coordinate c){
		Path p = paths [paths.Count - 1].GetComponent<Path> ();
		return (Mathf.Abs ((Mathf.Abs (p.coordinate.x) - Mathf.Abs (c.x))) +
						Mathf.Abs ((Mathf.Abs (p.coordinate.y) - Mathf.Abs (c.y)))) == 1;
	}

	private PathPiece.Direction GetGoingDirection(Coordinate c){
		Coordinate b = paths [paths.Count - 1].GetComponent<Path> ().coordinate;
		if ((c.x == b.x) && (c.y == (b.y-1))){
			return PathPiece.Direction.UP;
		} else if ((c.x == b.x) && (c.y == (b.y+1))){
			return PathPiece.Direction.DOWN;
		} else if ((c.x == (b.x+1)) && (c.y == b.y)){
			return PathPiece.Direction.RIGHT;
		} else if ((c.x == (b.x-1)) && (c.y == b.y)){
			return PathPiece.Direction.LEFT;
		} else return PathPiece.Direction.NONE;
	}

	public void ResetPaths(){
		while(paths.Count > 0){
			Station s = paths[paths.Count - 1].GetComponent<Path>().source.GetComponent<Station>();
			s.isBinded = false;
			s.brotherStation.GetComponent<Station>().isBinded = false;
			paths[paths.Count - 1].GetComponent<Path>().RemoveAllPath();
			Destroy (paths[paths.Count - 1]);
			paths.Remove (paths[paths.Count - 1]);

			if (paths.Count <= 0) {
				cancelButton.interactable = false;
				restartButton.interactable = false;
			}
		}
	}

	public void ResetBoard(){
		state = State.Begin;
		ResetPaths ();
		freeCoordinates.Clear ();
		while (boardPieces.Count > 0) {
			Destroy(boardPieces[boardPieces.Count - 1]);
			boardPieces.Remove(boardPieces[boardPieces.Count - 1]);
		}
		while (stations.Count > 0) {
			Destroy(stations[stations.Count - 1]);
			stations.Remove(stations[stations.Count - 1]);
		}
	}

	private void DeleteLastPast(){
		Path p = paths[paths.Count - 1].GetComponent<Path>();
		p.RemoveAllPath ();
		Destroy (p.gameObject);
		paths.Remove (p.gameObject);
	}
	
	private void SetSelectedStation(bool isSelected, bool isBinded){
		Station s = selectedStation.GetComponent<Station> ();
		s.isBinded = isBinded;
		s.brotherStation.GetComponent<Station>().isBinded = isBinded;
		s.isSelected = isSelected;
		s.Draw ();

	}

	public void RemoveFreePlace(Coordinate c){
		for (int i = 0; i < freeCoordinates.Count; i++) {
			if (c.x == freeCoordinates[i].x && c.y == freeCoordinates[i].y){
				freeCoordinates.Remove(freeCoordinates[i]);
				break;
			}
		}
	}

	public bool isPlaceFree(Coordinate c){
		for (int i = 0; i < freeCoordinates.Count; i++) {
			if (c.x == freeCoordinates[i].x && c.y == freeCoordinates[i].y){
				return true;
			}
		}
		return false;
	}

	private bool isSelectedStation(GameObject station){
		if (selectedStation != null) {
			Coordinate sc = selectedStation.GetComponent<Station>().coordinate;
			Coordinate c = station.GetComponent<Station>().coordinate;
			return sc.x == c.x && sc.y == c.y;
		} else return false;
	}

	public bool isLevelComplete(){
		foreach (GameObject go in stations) {
			if (!go.GetComponent<Station>().isBinded) return false;		
		}
		return true;
	}


}
