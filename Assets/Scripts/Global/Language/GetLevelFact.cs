﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetLevelFact : MonoBehaviour
{

    public string[] idFact;
    public LevelChooser levelChooser;


    void GetFact()
    {
        GetComponentInChildren<Text>().text = LanguageText.Instance.GetFact(idFact[levelChooser.levelNb-1]).text;
        GetComponentsInChildren<Image>()[1].sprite = Resources.Load(LanguageText.Instance.GetFact(idFact[levelChooser.levelNb-1]).image, typeof(Sprite)) as Sprite;
    }
}
