using UnityEngine;
using System.Collections;

public class MapPopUpHandler : PopUpHandler
{
	public string idStory;
	public string idAlternativeStory;

	protected override System.Collections.Generic.Queue<string> GetTexts ()
	{
		if (PopUpHandler.AlreadySeen (idStory) || PopUpHandler.AlreadySeen (idAlternativeStory)) {
			return new System.Collections.Generic.Queue<string> ();
		} else {
			GameData gamedata = GameObject.FindWithTag ("GameControl").GetComponent<GameData> ();
			if (gamedata.mapVisited) {
				PopUpHandler.SetPopUpAlreadySeen (idAlternativeStory);
				return base.GetTexts (idAlternativeStory);
			} else {
				gamedata.mapVisited = true;
				PopUpHandler.SetPopUpAlreadySeen (idStory);
				return base.GetTexts (idStory);
			}
		}
	}
}
