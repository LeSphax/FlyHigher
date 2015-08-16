using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSrc;
	//public AudioSource musicSrc;


	public SoundManager instance;

	public void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void PlayAudioClip(AudioClip ac){
		efxSrc.clip = ac;
		efxSrc.Play ();
	}
}
