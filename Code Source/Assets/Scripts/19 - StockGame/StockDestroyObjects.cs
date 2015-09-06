using UnityEngine;
using System.Collections;

public class StockDestroyObjects : MonoBehaviour
{

    private GameObject gameController;
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.SendMessage("LoseLife");
        Destroy(other.gameObject);
    }
}
