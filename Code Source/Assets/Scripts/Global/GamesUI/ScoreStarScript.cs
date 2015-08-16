using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreStarScript : MonoBehaviour
{

    public Sprite starFull;
    public Sprite starEmpty;

    public void ShowStars(int numberStars)
    {
        Image[] stars = GetComponentsInChildren<Image>();
        switch (numberStars)
        {
            case 0:
                stars[0].sprite = starEmpty;
                stars[1].sprite = starEmpty;
                stars[2].sprite = starEmpty;
                break;
            case 1:
                stars[0].sprite = starFull;
                stars[1].sprite = starEmpty;
                stars[2].sprite = starEmpty;
                break;
            case 2:
                stars[0].sprite = starFull;
                stars[1].sprite = starFull;
                stars[2].sprite = starEmpty;
                break;
            case 3:
                stars[0].sprite = starFull;
                stars[1].sprite = starFull;
                stars[2].sprite = starFull;
                break;
        }
    }
}
