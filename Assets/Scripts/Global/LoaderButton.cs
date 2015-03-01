using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoaderButton: MonoBehaviour {

	public bool isLocked;
	public Button loaderButton;
	public Text title;
	public Text starsText;
	public Image uimage;
	public string titleText;

	public Sprite locksSprite;
	public Sprite starSprite;

	public void Start(){
		title.text = titleText;
		string name = GetComponent<buttonLoadScene>().name;
		Vector2 size = uimage.rectTransform.sizeDelta;
		Vector2 anchor = uimage.rectTransform.anchoredPosition;
		if (isLocked) {
			loaderButton.interactable = false;
			uimage.sprite = locksSprite;
			size.y = 60;
			size.x = 60;
			anchor.y = -15;
			uimage.rectTransform.sizeDelta = size;
			uimage.rectTransform.anchoredPosition = anchor;
			starsText.text = "";

		} else {
			GameData gameData = GameObject.FindWithTag("GameControl").GetComponent<GameData>();
			int numberStars = gameData.GetSceneData(name).numberStars;
			loaderButton.interactable = true;
			uimage.sprite = starSprite;
			size.y = 30;
			size.x = 30;
			anchor.y = 0;
			uimage.rectTransform.sizeDelta = size;
			uimage.rectTransform.anchoredPosition = anchor;
			//TODO if (isGame){
			setPoints(numberStars,3);
			//TODO} else {
			//int maxNumberStars = gameData.getSceneData(name).maxNumberStars);
			//setPoints(numberStars, maxNumberStars);
			//}
		}
		title.text = titleText;
	}

	private void setPoints(int nb, int nbMax){
		starsText.text = nb.ToString() + "/" + nbMax.ToString();
	}

}
