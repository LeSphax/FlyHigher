using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreStarScript : MonoBehaviour
{

		public Sprite starFull;
		public Sprite starEmpty;
        

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}


		public void SetStars (int numberOfStars)
		{
				Image[] stars = GetComponentsInChildren<Image> ();
				switch (numberOfStars) {
				case 1:
						stars [0].sprite = starFull;
						stars [1].sprite = starEmpty;
						stars [2].sprite = starEmpty;
						break;
				case 2:
						stars [0].sprite = starFull;
						stars [1].sprite = starFull;
						stars [2].sprite = starEmpty;
						break;
				case 3:
						stars [0].sprite = starFull;
						stars [1].sprite = starFull;
						stars [2].sprite = starFull;
						break;
				}
		}
}
