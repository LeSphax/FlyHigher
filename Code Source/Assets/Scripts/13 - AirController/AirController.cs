﻿using UnityEngine;
using UnityEngine.UI;
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

    GameObject radarDot;
    GameObject otherPlane;
    AudioClip explosionSound;

    public Text lifeText;

    
    bool endOfGame = false;
    float radarRadius = 3.33f;

    void Awake()
    {
        otherPlane = Resources.Load("AirController/OtherPlane",typeof(GameObject)) as GameObject;
        radarDot = Resources.Load("AirController/RadarDot", typeof(GameObject)) as GameObject;
        explosionSound = Resources.Load("AirController/BIG Explosion", typeof(AudioClip)) as AudioClip;
    }

    void Start()
    {
        timeBetweenPlanes = startingTimeBetweenPlanes;
        RefreshLifeText();
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
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, 0.3f);
        Invoke("OtherPlaneDestroyed", 2); // Called after two seconds so the Imminent Collision red flashing won't stop instantaneously.
        StartFlashing();
        Invoke("StopFlashing", 3.0f);
        numberOfLives--;
        RefreshLifeText();
        if (numberOfLives <= 0)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
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
        gameObject.GetComponent<Animation>().Play();
    }

    void StopFlashing()
    {
        gameObject.GetComponent<Animation>().Stop();
        GetComponent<Renderer>().enabled = true;
    }

    void RefreshLifeText()
    {
        lifeText.text = numberOfLives.ToString();
    }

}

