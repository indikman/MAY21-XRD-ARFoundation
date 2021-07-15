using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public int lives = 10;

    public Canvas gameOverCanvas;

    public TMP_Text livesText;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        RestartGame();
       
    }

    public void LostLife()
    {
        lives--;

        livesText.text = lives.ToString();

        if (lives <= 0)
        {
            //Game over!!
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        lives = 10;
        livesText.text = lives.ToString();
        gameOverCanvas.gameObject.SetActive(false);
    }


}
