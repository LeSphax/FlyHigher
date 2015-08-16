using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HelpUI : AbstractHelpUI {

	protected override void SetMinAndMax (){
		this.min = 0;
		this.max = helpSprites.Length - 1;
	}

	protected override bool ShouldBeVisibleAtLaunch () {
		return numberStars == 0;
	}
}
