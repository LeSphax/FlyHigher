using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{


    public int nbDotsAtATime;
    public int nbDotsToCatch;
    int nbDotsPresent;

    public GameObject radarDot;

    float radarRadius = 3.33f;


    void Start()
    {
        int i;
        for (i = 0; i < nbDotsAtATime; i++)
        {
            SpawnADot();
        }
    }
    void Update()
    {

        if (nbDotsToCatch == 0)
        {
            EndOfGame();
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 300, 100, 100), "Points à attraper:" + nbDotsToCatch);
    }

    public void DotDestroyed()
    {
        nbDotsToCatch--;
        nbDotsPresent--;
        if (nbDotsToCatch > nbDotsPresent)
        {
            SpawnADot();
        }
    }

    void SpawnADot()
    {
        Vector2 newPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        while (Vector2.Distance(new Vector2(transform.localPosition.x, transform.localPosition.y), newPosition) < 2)
        {
            newPosition = Random.insideUnitCircle * radarRadius;
        }
        Instantiate(radarDot, new Vector3(newPosition.x, newPosition.y, 0), new Quaternion(0, 0, 0, 0));
        nbDotsPresent++;
    }

    void EndOfGame()
    {

    }
}
