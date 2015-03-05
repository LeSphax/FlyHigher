using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapManager : MonoBehaviour {

	public GameObject laboratoryLoader;
	public GameObject hangarLoader;
	public GameObject controlTowerLoader;
	
	public Image hangarImage;
	public Image controlTowerImage;

	public Sprite hangarLocked;
	public Sprite controlTowerLocked;
	public Sprite hangarUnlocked;
	public Sprite controlTowerUnlocked;

	private SceneLoaderButton laboSLB;
	private SceneLoaderButton hangarSLB;
	private SceneLoaderButton controlTowerSLB;

	// Use this for initialization
	void Start () {
		laboSLB = laboratoryLoader.GetComponent<SceneLoaderButton> ();
		hangarSLB = hangarLoader.GetComponent<SceneLoaderButton> ();
		controlTowerSLB = controlTowerLoader.GetComponent<SceneLoaderButton> ();

		SetLocks ();

		laboSLB.Init ();
		hangarSLB.Init ();
		controlTowerSLB.Init ();
	}
	
	private void SetLocks (){
		//TODO 
		GameData gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
		string l = laboSLB.GetComponent<buttonLoadScene> ().sceneToLoad;
		if (gameData != null && l != null) {
			//if (gameData.GetBuildingData(l).gameFinished <  gameData.GetBuildingData(l).gameNb){
				hangarSLB.isLocked = true;
				hangarImage.sprite = hangarLocked;
				controlTowerSLB.isLocked = true;
				controlTowerImage.sprite = controlTowerLocked;
			/*} else {
				hangarSLB.isLocked = false;
				hangarImage.sprite = hangarUnlocked;
				string h = hangarSLB.GetComponent<buttonLoadScene> ().sceneToLoad;
				if (h != null){
					if (gameData.GetBuildingData(h).gameFinished <  gameData.GetBuildingData(l).gameNb){
						controlTowerSLB.isLocked = true;
						controlTowerImage.sprite = controlTowerLocked;
					} else {
						controlTowerSLB.isLocked = true;
						controlTowerImage.sprite = controlTowerUnlocked;
					}
				
				}
			}*/
		}
		if (true){
			
		} else {
		
		}
	}
}
