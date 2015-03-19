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
			if (gamedata.showAlternativeText) {
				PopUpHandler.SetPopUpAlreadySeen (idAlternativeStory);
				return base.GetTexts (idAlternativeStory);
			} else {
				gamedata.showAlternativeText = true;
				PopUpHandler.SetPopUpAlreadySeen (idStory);
				return base.GetTexts (idStory);
			}
		}
	}
}
