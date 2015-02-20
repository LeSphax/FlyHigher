using UnityEngine;
using System.Collections;

public class AirController : MonoBehaviour
{


    public int nbDotsAtATime;
    public int nbDotsToCatch;
    int nbDotsCaught = 0;

    public GameObject radarDot;
    public GameObject otherPlane;
    bool endOfGame = false;
    float radarRadius = 3.33f;


    void Start()
    {
        int i;
        for (i = 0; i < nbDotsAtATime; i++)
        {
            SpawnADot();
        }
        SpawnPlane();
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
        nbDotsCaught++;
        if (nbDotsToCatch > 0)
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
    }

    void EndOfGame()
    {
        endOfGame = true;
    }

    void CollisionWithAirplane()
    {
        Destroy(gameObject);
        EndOfGame();

    }

    void SpawnPlane()
    {
        if (nbDotsCaught > 0 && !endOfGame)
        {
            RandomPlaneTransform((GameObject)Instantiate(otherPlane), Random.Range(0, 4), Random.Range(-radarRadius / 2, radarRadius / 2));
        }
        Invoke("SpawnPlane", 4);
    }

    void RandomPlaneTransform(GameObject newPlane, float rotation, float position)
    {
        if (rotation < 1.0f)
        {
            newPlane.transform.localPosition = new Vector2(-radarRadius, position);
            newPlane.transform.Rotate(new Vector3(0, 0, 270));
        }
        else if (rotation < 2.0f)
        {
            newPlane.transform.localPosition = new Vector2(radarRadius, position);
            newPlane.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (rotation < 3.0f)
        {
            newPlane.transform.localPosition = new Vector2(position, -radarRadius);
            newPlane.transform.Rotate(new Vector3(0, 0, 0));
        }
        else
        {
            newPlane.transform.localPosition = new Vector2(position, radarRadius);
            newPlane.transform.Rotate(new Vector3(0, 0, 180));
        }
    }

}

