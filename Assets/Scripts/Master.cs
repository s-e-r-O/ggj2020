using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    private int seconds;
    public Text clockText;
    public Text gameOverText;
    private int numberOfPlayers = 2;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTimer());
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire12"))
        {
            Restart();
        }
    }

    public void AnnounceDeath()
    {
        numberOfPlayers--;
        if (numberOfPlayers == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        StopCoroutine(StartTimer());
        gameOverText.text = "GAME OVER";
        isGameOver = true;
    }

    void Restart()
    {
        seconds = 0;
        gameOverText.text = "";
    numberOfPlayers = 2;
    UnityEngine.Application.LoadLevel(UnityEngine.Application.loadedLevel);
    }

    IEnumerator StartTimer() 
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            seconds++;
            string leadingH = seconds / 60 > 9 ? "" : "0";
            string leadings = seconds % 60 > 9 ? "" : "0";
            clockText.text = $"{leadingH}{seconds / 60}:{leadings}{seconds % 60}";
        }
    }
}
