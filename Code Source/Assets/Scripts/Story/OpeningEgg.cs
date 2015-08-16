using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OpeningEgg : MonoBehaviour {

    public GameObject egg;
    public GameObject plane;
    public Sprite[] eggSprites;
    public AudioClip crackSound;
    public string sceneToLoad;

    private int i;

    public void Crack()
    {
        AudioSource.PlayClipAtPoint(crackSound, transform.position);
        i++;
        if (i < eggSprites.Length)
        {
            egg.GetComponent<Image>().sprite = eggSprites[i];
        }
    }

    public void StartLanding(){
        plane.audio.Play();
        plane.animation.Play();
    }

    public void EndAnimation()
    {
        GameObject.FindWithTag("MainCamera").SendMessage("PopUpAppear");
    }
}
