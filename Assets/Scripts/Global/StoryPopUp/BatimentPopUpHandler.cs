using UnityEngine;
using System.Collections;

public class BatimentPopUpHandler : PopUpHandler
{
	public string idStory;

	private static bool alreadySeen = false;

	protected override System.Collections.Generic.Queue<string> GetTexts ()
	{
		if (PopUpHandler.AlreadySeen (idStory)) {
			return new System.Collections.Generic.Queue<string> ();
		}
		PopUpHandler.SetPopUpAlreadySeen (idStory);
		return GetTexts (idStory);
	}
}
