﻿using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI ScorePlayer1;
    public TextMeshProUGUI ScorePlayer2;

    void Start()
    {
        if(instance == null)
        {
            ScorePlayer1.text = "x0";
            ScorePlayer2.text = "0x";
            instance = this;
        }
    }

    public void ChangeScorePlayer1(int value)
    {
        ScorePlayer1.text = "x" + value.ToString();
    }

    public void ChangeScorePlayer2(int value)
    {
        ScorePlayer2.text = value.ToString() + "x";
    }
}