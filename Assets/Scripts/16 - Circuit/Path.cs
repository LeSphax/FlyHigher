using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	
	public GameObject firstPathPiece;
	public GameObject middlePathPiece;
	public GameObject lastPathPiece;
	public GameObject board;

	private List <GameObject> pathPieces = new List<GameObject> ();
	private Coordinate begin;
	private Coordinate end;
	[HideInInspector] public Coordinate coordinate;

	public Path (GameObject board, Coordinate begin, Coordinate end){
		this.board = board;
		this.begin = begin;
		this.coordinate = begin;
		this.end = end;
	}

	public bool AddPathPiece (PathPiece.Direction d) {
		GameObject instance;
		//TODO Check if path is not complete
		if (coordinate == begin) {
			GameObject firstInstance = Instantiate (firstPathPiece) as GameObject;
			PathFirstPiece pfp = firstInstance.GetComponent<PathFirstPiece>();
			pfp.Init(board, coordinate.x, coordinate.y, d);
			pfp.Draw ();
			pathPieces.Add(firstInstance);
		} else {
			PathMiddlePiece pmp = pathPieces[pathPieces.Count - 1].GetComponent<PathMiddlePiece> ();
			pmp.UpdateGoingDirection(d);
		}

		UpdateXY (d);

		if (coordinate == end) {
			instance = Instantiate (lastPathPiece) as GameObject;
			PathLastPiece plp = instance.GetComponent<PathLastPiece> ();
			plp.Init(board, coordinate.x, coordinate.y, PathPiece.OppositeDirection (d));
			plp.Draw();
			return true;
		} else {
			instance = Instantiate (middlePathPiece) as GameObject;
			PathMiddlePiece pmp = instance.GetComponent<PathMiddlePiece> ();
			pmp.Init(board, coordinate.x, coordinate.y, PathPiece.OppositeDirection (d), PathPiece.Direction.NONE);
			pmp.Draw();
			return false;
		}
	}

	public void UpdateXY (PathPiece.Direction d){
		if (d == PathPiece.Direction.UP) coordinate.y--;
		else if (d == PathPiece.Direction.DOWN) coordinate.y++;
		else if (d == PathPiece.Direction.RIGHT) coordinate.x++;
		else if (d == PathPiece.Direction.LEFT) coordinate.x--;
	}

	public bool isMovePossible(PathPiece.Direction d){
		if (coordinate == end) return true; 
		BoardManager bm = board.GetComponent<BoardManager> ();
		if (d == PathPiece.Direction.UP)
			return bm.isPlaceFree(new Coordinate(coordinate.x, coordinate.y - 1));
		else if (d == PathPiece.Direction.DOWN)
			return bm.isPlaceFree(new Coordinate(coordinate.x, coordinate.y + 1));
		else if (d == PathPiece.Direction.RIGHT)
			return bm.isPlaceFree(new Coordinate(coordinate.x + 1, coordinate.y));
		else if (d == PathPiece.Direction.DOWN)
			return bm.isPlaceFree(new Coordinate(coordinate.x - 1, coordinate.y));
		else return false;
	}

	/*public Sprite stationPathSprite;
	public Sprite halfPathSprite;
	public Sprite pathSprite;
	public Sprite anglePathSprite;

	[HideInInspector] public int x;
	[HideInInspector] public int y;
	[HideInInspector] public bool isLast;

	private void SetImage (PathManager.Move moveComming, PathManager.Move moveGoing){
		Quaternion rotation = GetComponent<RectTransform> ().localRotation;
		if (moveComming != PathManager.Move.Null || moveGoing != PathManager.Move.Null) {
			if (moveComming == PathManager.Move.Null) {
				GetComponent<Image> ().sprite = stationPathSprite;
				if (moveGoing == PathManager.Move.Up){
					rotation.z = 180;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if (moveGoing == PathManager.Move.Down) {
					rotation.z = 0;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if (moveGoing == PathManager.Move.Right){
					rotation.z = 90;
					GetComponent<RectTransform>().localRotation = rotation;
				} else {
					rotation.z = 270;
					GetComponent<RectTransform>().localRotation = rotation;
				}
			} else if (moveGoing == PathManager.Move.Null) {
				GetComponent<Image> ().sprite = halfPathSprite;
				if (moveComming == PathManager.Move.Up){
					rotation.z = 0;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if (moveComming == PathManager.Move.Down) {
					rotation.z = 180;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if (moveComming == PathManager.Move.Right){
					rotation.z = 270;
					GetComponent<RectTransform>().localRotation = rotation;
				} else {
					GetComponent<RectTransform>().localRotation = rotation;
					rotation.z = 90;
				}
			} else {
				if ((moveGoing == PathManager.Move.Up && 
				     moveComming == PathManager.Move.Down)
				    || (moveGoing == PathManager.Move.Down && 
				    moveComming == PathManager.Move.Up)){
					GetComponent<Image> ().sprite = pathSprite;
					rotation.z = 0;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if ((moveGoing == PathManager.Move.Left && 
				    moveComming == PathManager.Move.Right)
					|| (moveGoing == PathManager.Move.Right && 
					moveComming == PathManager.Move.Left)){
					GetComponent<Image> ().sprite = pathSprite;
					rotation.z = 90;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if ((moveGoing == PathManager.Move.Right && 
				            moveComming == PathManager.Move.Up)
				           || (moveGoing == PathManager.Move.Down && 
				    moveComming == PathManager.Move.Left)){
					GetComponent<Image> ().sprite = anglePathSprite;
					rotation.z = 0;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if ((moveGoing == PathManager.Move.Right && 
				            moveComming == PathManager.Move.Down)
				           || (moveGoing == PathManager.Move.Up && 
				    moveComming == PathManager.Move.Left)){
					GetComponent<Image> ().sprite = anglePathSprite;
					rotation.z = 90;
					GetComponent<RectTransform>().localRotation = rotation;
				} else if ((moveGoing == PathManager.Move.Up && 
				            moveComming == PathManager.Move.Right)
				           || (moveGoing == PathManager.Move.Left && 
				    moveComming == PathManager.Move.Down)){
					GetComponent<Image> ().sprite = anglePathSprite;
					rotation.z = 180;
					GetComponent<RectTransform>().localRotation = rotation;
				} else {
					GetComponent<Image> ().sprite = anglePathSprite;
					rotation.z = 180;
					GetComponent<RectTransform>().localRotation = rotation;
				}
			}
		}
	}

	public void SetMove (PathManager.Move mc, PathManager.Move mg){
		SetImage (mc, mg);
	}
	*/
}
