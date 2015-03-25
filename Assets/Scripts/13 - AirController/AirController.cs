using UnityEngine;
using System.Collections;

public class AirController : MonoBehaviour
{


    public int nbDotsToCatch;
    public int nbDotsBeforePlanes;
    public float startingTimeBetweenPlanes;
    public float minimumTimeBetweenPlanes;
    public int numberOfLives;

    int nbDotsCaught;
    float timeBetweenPlanes;

    public GameObject radarDot;
    public GameObject otherPlane;
    public AudioClip explosionSound;

    
    bool endOfGame = false;
    float radarRadius = 3.33f;


    void Start()
    {
        timeBetweenPlanes = startingTimeBetweenPlanes;
        nbDotsCaught = 0;
        SpawnADot();
        SpawnOtherPlanes();
    }
    void Update()
    {

        if (nbDotsToCatch == 0)
        {
            Invoke("GameEnded", 1.0f);
        }
    }


    public void DotDestroyed()
    {
        if (nbDotsCaught >= nbDotsBeforePlanes)
            timeBetweenPlanes -= (startingTimeBetweenPlanes - minimumTimeBetweenPlanes) / ((nbDotsToCatch+nbDotsCaught) - nbDotsBeforePlanes);
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
        Invoke("OtherPlaneDestroyed", 2); // Called after two seconds so the Imminent Collision red flashing won't stop instantaneously.
        StartFlashing();
        Invoke("StopFlashing", 3.0f);
        numberOfLives--;
        if (numberOfLives <= 0)
        {
            gameObject.renderer.enabled = false;
            Invoke("GameEnded",1.0f);
        }

    }

    void SpawnOtherPlanes()
    {
        if (nbDotsCaught >= nbDotsBeforePlanes && !endOfGame)
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

    // Signal the Nearby planes detecter that a plane which have been destroyed isn't in the danger zone anymore.
    void OtherPlaneDestroyed()
    {
        gameObject.BroadcastMessage("OtherPlaneExited");
    }

    void StartFlashing()
    {
        gameObject.animation.Play();
    }

    void StopFlashing()
    {
        gameObject.animation.Stop();
        renderer.enabled = true;
    }

}

