using UnityEngine;
using System.Collections;

public abstract class AbstractLevel : MonoBehaviour {

	public abstract void LoadLevel(int levelNb);

	/**
	 * Doit permettre de nettoyer le niveau si nécéssaire pour le 
	 * reset du niveau
	 **/
	public abstract void Clear();

}
