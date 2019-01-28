using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineController : MonoBehaviour {

    public GameObject gameOverScreen;

    private void gameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision);
            gameOver();
        }
    }


}
