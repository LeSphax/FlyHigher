using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	
	public GameObject firstPathPiece;
	public GameObject middlePathPiece;
	public GameObject lastPathPiece;
	public GameObject board;

	public GameObject source;
	public GameObject target;

	[HideInInspector] public Coordinate coordinate;
	[HideInInspector] public List <GameObject> pathPieces = new List<GameObject> ();

	private Coordinate begin;
	private Coordinate end;
	
	public void Init (GameObject board, GameObject source){
		this.board = board;
		this.source = source;
		Station s = source.GetComponent<Station> ();
		this.target = s.brotherStation;
		begin = new Coordinate (s.coordinate.x, s.coordinate.y);
		coordinate = new Coordinate (s.coordinate.x, s.coordinate.y);

		end = new Coordinate (this.target.GetComponent<Station> ().coordinate.x, this.target.GetComponent<Station> ().coordinate.y);
		board.GetComponent<BoardManager> ().paths.Add (gameObject);
	}

	private bool isMovePossible (PathPiece.Direction d) {
		Coordinate nc = UpdateCoordinate (coordinate, d);
		if (nc.x == end.x && nc.y == end.y) return true;
		else {
			return board.GetComponent<BoardManager>().isPlaceFree(nc);
		}
	}

	private Coordinate UpdateCoordinate(Coordinate c, PathPiece.Direction d){
		Coordinate nc;
		if (d == PathPiece.Direction.DOWN) {
			nc = new Coordinate(c.x, c.y + 1);
		} else if (d == PathPiece.Direction.UP) {
			nc = new Coordinate(c.x, c.y - 1);
		} else if (d == PathPiece.Direction.RIGHT) {
			nc = new Coordinate(c.x + 1, c.y);
		} else if (d == PathPiece.Direction.LEFT) {
			nc = new Coordinate(c.x - 1, c.y);
		} else {
			nc = c;
		}
		return nc;
	}

	public bool AddPathPiece (PathPiece.Direction d){
		if (isMovePossible (d)) {
			GameObject instance;
			if (coordinate.x == begin.x && coordinate.y == begin.y){
				GameObject firstInstance = Instantiate (firstPathPiece) as GameObject;
				PathFirstPiece pfp = firstInstance.GetComponent<PathFirstPiece>();
				pfp.Init(board, coordinate.x, coordinate.y, d);
				pfp.Draw();
				pathPieces.Add(firstInstance);
			} else {
				PathMiddlePiece pmp = pathPieces[pathPieces.Count - 1].GetComponent<PathMiddlePiece> ();
				pmp.UpdateGoingDirection(d);
			}

			coordinate = UpdateCoordinate (coordinate, d);


			if (coordinate.x == end.x && coordinate.y == end.y) {
				instance = Instantiate (lastPathPiece) as GameObject;
				PathLastPiece plp = instance.GetComponent<PathLastPiece> ();
				plp.Init(board, coordinate.x, coordinate.y, PathPiece.OppositeDirection (d));
				plp.Draw();
				pathPieces.Add(instance);
				return true;
			} else {
				board.GetComponent<BoardManager>().RemoveFreePlace(coordinate);
				instance = Instantiate (middlePathPiece) as GameObject;
				PathMiddlePiece pmp = instance.GetComponent<PathMiddlePiece> ();
				pmp.Init(board, coordinate.x, coordinate.y, PathPiece.OppositeDirection (d), PathPiece.Direction.NONE);
				pmp.Draw();
				pathPieces.Add(instance);
				return false;
			}
		} else {
			//TODO PLAY ANNIMATION
			return false;
		}
	}

	public void RemoveLastPathPiece(){
		BoardManager bm = board.GetComponent<BoardManager> ();
		PathPiece.Direction d;
		if (pathPieces.Count > 2) {
			if (coordinate.x == end.x && coordinate.y == end.y){
				d = pathPieces[pathPieces.Count - 1].GetComponent<PathLastPiece>().comming;
			} else {
				d = pathPieces[pathPieces.Count - 1].GetComponent<PathMiddlePiece>().comming;
				bm.freeCoordinates.Add(new Coordinate(coordinate.x, coordinate.y));
			} 
			DeleteLastPathPiece();
			PathMiddlePiece pmp = pathPieces[pathPieces.Count - 1].GetComponent<PathMiddlePiece>();
			pmp.UpdateGoingDirection(PathPiece.Direction.NONE);
			coordinate.x = pmp.coordinate.x;
			coordinate.y = pmp.coordinate.y;
		} else if (pathPieces.Count == 2){
			if (coordinate.x == end.x && coordinate.y == end.y){
				d = pathPieces[pathPieces.Count - 1].GetComponent<PathLastPiece>().comming;
			} else {
				d = pathPieces[pathPieces.Count - 1].GetComponent<PathMiddlePiece>().comming;
				bm.freeCoordinates.Add(new Coordinate(coordinate.x, coordinate.y));
			}
			DeleteLastPathPiece();
			DeleteLastPathPiece();
			coordinate.x = begin.x;
			coordinate.y = begin.y;
		}
	}

	private void BackCoordinate(PathPiece.Direction comming){

	}

	private void DeleteLastPathPiece(){
		GameObject p = pathPieces [pathPieces.Count - 1];
		Destroy (p);
		pathPieces.Remove (p);
	}

	public void RemoveAllPath(){
		while (pathPieces.Count > 0) {
			RemoveLastPathPiece();		
		}
	}
}
