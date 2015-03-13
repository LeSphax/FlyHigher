using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButton : MonoBehaviour {

	public Image locksImage;
	public Image background;
	public Text levelText;
	public Button button;

	private LevelChooser levelChooser;
	private int levelNb;

	public void Init(LevelChooser levelChooser, int levelNb, bool isLocked, int x, int y, float offset){
		levelText.text = levelNb.ToString();
		this.levelChooser = levelChooser;
		this.levelNb = levelNb;
		ResizeButton (x, y, offset);
		if (isLocked) {
			button.enabled = false;
			locksImage.gameObject.SetActive(true);
			levelText.gameObject.SetActive(false);
		} else {
			button.enabled = true;
			locksImage.gameObject.SetActive (false);
			levelText.gameObject.SetActive(true);
		}
	}

	private void ResizeButton(int x, int y, float offset){
		float s = (levelChooser.height / 4f);
		RectTransform rtButton = GetComponent<RectTransform> ();
		rtButton.SetParent (levelChooser.panel.GetComponent<RectTransform> ());
		rtButton.sizeDelta = new Vector2 (s, s);
		rtButton.anchoredPosition = new Vector2 ((((s) / 2f) + ((s + offset) * x) + offset), -(((s) / 2f) + ((s + offset) * y) + offset));
		rtButton.localScale = new Vector3 (1f, 1f, 1f);
		RectTransform rtBackground = background.GetComponent<RectTransform> ();
		rtBackground.SetParent (rtButton);
		rtBackground.sizeDelta = new Vector2 (s, s);
		rtBackground.anchoredPosition = new Vector2 (0f, 0f);
		rtBackground.localScale = new Vector3 (1f, 1f, 1f);
		RectTransform rtLocks = locksImage.GetComponent<RectTransform> ();
		rtLocks.SetParent (rtButton);
		rtLocks.sizeDelta = new Vector2 (s, s);
		rtLocks.anchoredPosition = new Vector2 (0f, 0f);
		rtLocks.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
		rtLocks.sizeDelta = new Vector2 (s, s);
	}

	public void Click(){
		levelChooser.LoadLevel (levelNb);
	}
}
