using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public GameObject boardPiece;
	public GameObject station;
	public GameObject path;
	public GameObject gameController;
	public GameObject gameManager;

	public Button cancelButton;
	public Button restartButton;

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

	public void StationClicked(GameObject station){
		if (selectedStation == null && paths.Count == 0) restartButton.gameObject.SetActive (true);
		if (!isSelectedStation (station) && !station.GetComponent<Station>().isBinded) {
			if (selectedStation != null){
				if (paths.Count > 0) {
					GameObject p = paths[paths.Count -1];
					p.GetComponent<Path>().RemoveAllPath(); 
					Destroy (p); 
					paths.Remove(p);
				}
			}
			ChangeSelectedStation(station);
			GameObject instance = Instantiate (path) as GameObject;
			instance.GetComponent<Path> ().Init(gameObject, selectedStation);
			if (paths.Count == 1){
				cancelButton.gameObject.SetActive(false);
			}
		}
	}

	public void CancelLastMove(){
		Path p = paths [paths.Count - 1].GetComponent<Path> ();
		if (p.pathPieces.Count > 0) {
			p.RemoveLastPathPiece();	
			if (selectedStation == null){
				selectedStation = p.source;
				Station s = selectedStation.GetComponent<Station>();
				s.isBinded = false;
				s.brotherStation.GetComponent<Station>().isBinded = false;
				s.isSelected = true;
				s.Draw();
			}
			if (paths.Count == 1 && paths[0].GetComponent<Path>().pathPieces.Count == 0)
				cancelButton.gameObject.SetActive(false);
		} else {
			if (paths.Count > 1){
				Destroy (paths[paths.Count - 1]);
				paths.Remove(paths[paths.Count -1]);
				p = paths [paths.Count - 1].GetComponent<Path> ();
				if (selectedStation != null){
					Station s = selectedStation.GetComponent<Station>();
					s.isSelected = false;
					s.Draw();
				}
					selectedStation = p.source;
					Station ns = selectedStation.GetComponent<Station>();
					ns.isBinded = false;
					ns.brotherStation.GetComponent<Station>().isBinded = false;
					ns.isSelected = true;
					ns.Draw();
					p.RemoveLastPathPiece();
			}



		}
	}

	public void Restart(){
		while (paths[0].GetComponent<Path>().pathPieces.Count > 0) {
			CancelLastMove();		
		}
		Destroy (paths [0]);
		paths.Remove (paths [0]);
		if (selectedStation != null){ 
			Station s = selectedStation.GetComponent <Station>();
			s.isSelected = false;
			s.Draw();
			selectedStation = null;
		}
		restartButton.gameObject.SetActive (false);
	}

	public void MoveAction(PathPiece.Direction d){
		if (selectedStation != null) {
			if (paths.Count == 1 && paths[0].GetComponent<Path>().pathPieces.Count == 0) 
				cancelButton.gameObject.SetActive(true);
			if (paths[paths.Count - 1].GetComponent<Path>().AddPathPiece(d)){
				Station s = selectedStation.GetComponent<Station>();
				s.isSelected = false;
				s.Draw();
				s.isBinded = true;
				s.brotherStation.GetComponent<Station>().isBinded = true;
				selectedStation = null;
			}
		}
		if (isLevelComplete ()) {
			gameManager.GetComponent<CircuitGameManager>().LevelEnded();		
		}
	}

	public void ChangeSelectedStation(GameObject station){
		if (selectedStation != null) {
			Station s = selectedStation.GetComponent<Station>();
			s.isSelected = false;
			s.Draw();
		}
		selectedStation = station;
		Station ns = selectedStation.GetComponent<Station> ();
		ns.isSelected = true;
		ns.Draw();
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
