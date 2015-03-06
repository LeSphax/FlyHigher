using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public GameObject boardPiece;
	public GameObject station;

	[HideInInspector] public int size;
	[HideInInspector] public float width;
	[HideInInspector] public float height;
	[HideInInspector] public List <Coordinate> freeCoordinates = new List<Coordinate> ();

	private List <GameObject> boardPieces = new List <GameObject> ();
	private List <Ensemble> ensembles = new List<Ensemble> ();
	public void Init (int s){
		size = s;
		RectTransform rt = GetComponent<RectTransform> ();
		width = rt.sizeDelta.x;
		height = rt.sizeDelta.y;
	}

	public void GenerateBoard (){
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

	public void SetEnsembles(List<Ensemble> le){
		ensembles = le;
	}

	public bool isPlaceFree(Coordinate c){
		for (int i = 0; i < freeCoordinates.Count; i++) {
			if (freeCoordinates[i] == c) return true;		
		}
		return false;
	}
}
