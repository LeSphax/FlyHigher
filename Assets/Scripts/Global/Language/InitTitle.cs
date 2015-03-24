using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitTitle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = LanguageText.Instance.GetSceneName(Application.loadedLevelName);
    }
}
