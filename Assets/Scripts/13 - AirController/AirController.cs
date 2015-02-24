using UnityEngine;
using System.Collections;

public class AirController : MonoBehaviour
{


    public int nbDotsToCatch;
    public int timeBetweenPlanes;
    public int numberOfLives;
    int nbDotsCaught;

    public GameObject radarDot;
    public GameObject otherPlane;
    public AudioClip explosionSound;

    
    bool endOfGame = false;
    float radarRadius = 3.33f;


    void Start()
    {
        nbDotsCaught = 0;
        SpawnADot();
        SpawnOtherPlanes();
    }
    void Update()
    {

        if (nbDotsToCatch == 0)
        {
            GameEnded();
        }
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

    void GameEnded()
    {
        GameObject gameUI= GameObject.FindGameObjectWithTag("Interface");
        gameUI.BroadcastMessage("GameEnded",numberOfLives);
        endOfGame = true;
    }

    void CollisionWithAirplane()
    {        
        if (explosionSound)
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        numberOfLives--;
        if (numberOfLives <= 0)
        {
            Destroy(gameObject);
            GameEnded();
        }

    }

    void SpawnOtherPlanes()
    {
        if (nbDotsCaught > 0 && !endOfGame)
        {
            RandomPlaneTransform((GameObject)Instantiate(otherPlane), Random.Range(0, 4), Random.Range(-radarRadius / 2, radarRadius / 2));
        }
        Invoke("SpawnOtherPlanes", timeBetweenPlanes);
    }

    void RandomPlaneTransform(GameObject newPlane, float rotation, float position)
    {
        float distanceToCenter = radarRadius + 0.5f;
        if (rotation < 1.0f)
        {
            newPlane.transform.localPosition = new Vector2(-distanceToCenter, position);
            newPlane.transform.Rotate(new Vector3(0, 0, 270));
        }
        else if (rotation < 2.0f)
        {
            newPlane.transform.localPosition = new Vector2(distanceToCenter, position);
            newPlane.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (rotation < 3.0f)
        {
            newPlane.transform.localPosition = new Vector2(position, -distanceToCenter);
            newPlane.transform.Rotate(new Vector3(0, 0, 0));
        }
        else
        {
            newPlane.transform.localPosition = new Vector2(position, distanceToCenter);
            newPlane.transform.Rotate(new Vector3(0, 0, 180));
        }
    }

}

