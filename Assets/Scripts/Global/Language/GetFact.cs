using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetFact : MonoBehaviour {

    public string idFact;

    void Start()
    {
        GetComponentInChildren<Text>().text = LanguageText.Instance.GetFact(idFact).text;
        GetComponentsInChildren<Image>()[1].sprite = Resources.Load(LanguageText.Instance.GetFact(idFact).image, typeof(Sprite)) as Sprite;
    }
}
