﻿using UnityEngine;
using System.Collections;

public class BatimentPopUpHandler : PopUpHandler
{
	public string idFirstEntrance;
	public string idFinished;

	protected override System.Collections.Generic.Queue<string> GetTexts ()
	{
		if (AlreadySeen (idFirstEntrance)) {
			if (!AlreadySeen (idFinished)) {
				if (gameData.AreGamesCompletedInBuilding (Application.loadedLevelName) && idFinished !=null) {
					SetPopUpAlreadySeen (idFinished);
					return GetTexts (idFinished);
				}
			}
			return new System.Collections.Generic.Queue<string> ();
		} else {
			SetPopUpAlreadySeen (idFirstEntrance);
			return GetTexts (idFirstEntrance);
		}
	}
}
