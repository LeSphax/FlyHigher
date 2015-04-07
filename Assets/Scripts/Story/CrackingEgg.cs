using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrackingEgg : MonoBehaviour {


    public GameObject egg;
    public Sprite crackedEgg;
    public AudioClip crackSound;
    public string sceneToLoad;
    

    public void Crack()
    {
        AudioSource.PlayClipAtPoint(crackSound, transform.position);
        egg.GetComponent<Image>().sprite = crackedEgg;
    }

    public void EndAnimation()
    {
        Application.LoadLevel(sceneToLoad);
    }

}
