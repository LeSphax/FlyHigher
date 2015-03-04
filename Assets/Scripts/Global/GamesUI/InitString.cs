using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitString : MonoBehaviour
{

		public string idText;

		// Use this for initialization
		void Start ()
		{
				GetComponent<Text> ().text = LanguageText.Instance.GetUIText (idText);
		}
}
