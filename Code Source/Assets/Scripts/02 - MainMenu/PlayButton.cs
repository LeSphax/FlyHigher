using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    string firstCutScene="Beginning";
    string map = "Map";
    string idCinematic = "FirstCutScene";
    GameData gameData;

    void Awake(){
        gameData=GameObject.FindWithTag("GameControl").GetComponent<GameData>();
    }


    public void LoadScene(){
        if (!gameData.listPopUpSeen.Contains(idCinematic)){
            Application.LoadLevel(firstCutScene);
            gameData.listPopUpSeen.Add(idCinematic);
        }
        else {
            Application.LoadLevel(map);
        }
    }
}
