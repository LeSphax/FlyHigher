using UnityEngine;
using System.Collections;

public class PainterHelpUI : AbstractHelpUI {

	public LevelChooser lc;

	protected override void SetMinAndMax (){
		if (numberStars < 2){
			min = 0;
			max = 0;
		} else if (numberStars == 2) {
			min = 1;
			max = helpSprites.Length;		
		} else {
			min = 0;
			max = helpSprites.Length;
		}

	}
	
	protected override bool ShouldBeVisibleAtLaunch () {
		return numberStars == 0 || (lc.levelNb == 3 && numberStars == 2);
	}
}
