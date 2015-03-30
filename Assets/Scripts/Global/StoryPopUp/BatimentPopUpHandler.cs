using UnityEngine;
using System.Collections;

public class BatimentPopUpHandler : PopUpHandler
{
	public string idFirstEntrance;
    public string idFinished;

	protected override System.Collections.Generic.Queue<string> GetTexts ()
	{
        if (AlreadySeen(idFirstEntrance))
        {
            if (gameData.AreGamesCompletedInBuilding(Application.loadedLevelName))
            {
                SetPopUpAlreadySeen(idFinished);
                return GetTexts(idFinished);
            }
            return new System.Collections.Generic.Queue<string>();
        }
        else
        {
            SetPopUpAlreadySeen(idFirstEntrance);
            return GetTexts(idFirstEntrance);
        }
	}
}
