using UnityEngine;
using System.Collections;

public class LevelLoaderPaint : AbstractLevel
{
	public GameObject levelPrefab;

	private GameObject levelObject;
	private GameControlPaint controllerPaint;

	public override void LoadLevel (int nb)
	{
		levelObject = Instantiate (levelPrefab) as GameObject;
		controllerPaint = levelObject.GetComponentInChildren<GameControlPaint> ();
		controllerPaint.init (nb);
	}

	public override void Clear ()
	{
		controllerPaint.resetLevel ();
		Destroy (levelObject);
		Destroy (controllerPaint);
	}
}
