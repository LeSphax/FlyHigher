using UnityEngine;
using System.Collections;

public class OnClickReplay : MonoBehaviour
{

		public void Replay ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}
}
