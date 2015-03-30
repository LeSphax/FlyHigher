using UnityEngine;
using System.Collections;

public class MapPopUpHandler : PopUpHandler
{
	public string idStory;
	public string idAlternativeStory;

	protected override System.Collections.Generic.Queue<string> GetTexts ()
	{
		if (AlreadySeen (idStory) || AlreadySeen (idAlternativeStory)) {
			return new System.Collections.Generic.Queue<string> ();
		} else {
			if (AlreadySeen(idStory)) {
				SetPopUpAlreadySeen (idAlternativeStory);
				return base.GetTexts (idAlternativeStory);
			} else {
				SetPopUpAlreadySeen (idStory);
				return base.GetTexts (idStory);
			}
		}
	}
}
