using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlerTaches : MonoBehaviour
{
    public GameObject taches;
    public int nbTachesStart;
    private int nbeTachesSurEcran;
    public Text Tobjectifs;
    public Text TempsRestant;
    private bool gameOver;

    private float InitalTime;
    public float TimeGameOver = 60;

    public float StartTimeBetweenSpawn;
    private float TimeBetweenSpawn;
    public float MaxTimeBetweenSpawn;



    void Start()
    {
        InitalTime = Time.time;
        gameOver = true;
        nbeTachesSurEcran = 0;
        TimeBetweenSpawn = StartTimeBetweenSpawn;
        ApparitionTache();
        MajNbeTaches();
        StartCoroutine(SpawnTaches());

    }


    /* fonction qui fait apparaitre des taches */
    IEnumerator SpawnTaches()
    {
        //int nbeEnemies = 0;
        float x;
        float y;
        Vector3 spawnPosition;
        yield return new WaitForSeconds(0);
        while (gameOver)
        {
            x = Random.Range(-15, 15); //-22;22
            y = Random.Range(-10, 11); //-10;13
            spawnPosition = new Vector3(x, y, 0);
            Instantiate(taches, spawnPosition, Quaternion.identity);
            nbeTachesSurEcran++;
            MajNbeTaches();
            FinJeuTemps();
            float TimeElapsed = Time.time - InitalTime;
            TimeBetweenSpawn = StartTimeBetweenSpawn + TimeElapsed / TimeGameOver * (MaxTimeBetweenSpawn - StartTimeBetweenSpawn);
            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
    }


    //enléve des etoiles au fur et a mesure que le temps passe
    public void FinJeuTemps()
    {
        float TimeElapsed = Time.time - InitalTime;
        int TimeToShow = (int)(TimeGameOver - TimeElapsed);
        TempsRestant.text = TimeToShow.ToString();
        if (TimeElapsed > TimeGameOver)
        {
            int nbEtoiles = 0;
            GameObject.FindWithTag("GamesUI").SendMessage("GameEnded", nbEtoiles);
        }

    }




    //fait apparaitre nbeTaches d'un coups
    private void ApparitionTache()
    {
        float x;
        float y;
        int i;
        Vector3 spawnPosition;
        for (i = 0; i < nbTachesStart; i++)
        {
            x = Random.Range(-15, 15); //-22;22
            y = Random.Range(-10, 11); //-10;13
            spawnPosition = new Vector3(x, y, 0);
            Instantiate(taches, spawnPosition, Quaternion.identity); //fait apparaitre un chariot
            nbeTachesSurEcran++;
        }

    }

    //baisse le nombre de taches
    public void SupprimerTaches()
    {
        nbeTachesSurEcran--;
        MajNbeTaches();
        FinJeu();
    }



    //maj du texte donnant le nombre de taches restantes
    private void MajNbeTaches()
    {
        Tobjectifs.text = nbeTachesSurEcran.ToString();
    }



    //fonction qui doit etre appeler à la fin du jeu
    public void FinJeu()
    {
        if (nbeTachesSurEcran == 0)
        {
            float difSeconde = Time.time - InitalTime;
            int nbEtoiles;
            if (difSeconde > 40)
            {
                nbEtoiles = 1;
            }
            else if (difSeconde > 20)
            {
                nbEtoiles = 2;
            }
            else
            {
                nbEtoiles = 3;
            }
            GameObject.FindWithTag("GamesUI").SendMessage("GameEnded", nbEtoiles);
        }
    }


}
