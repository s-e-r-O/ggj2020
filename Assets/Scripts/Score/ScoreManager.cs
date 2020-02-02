using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScorePlayer1;
    public Text ScorePlayer2;

    public void ChangeScore(int value, int player)
    {
        if (player == 1)
        {
            ChangeScorePlayer1(value);
        }
        else
        {
            ChangeScorePlayer2(value);
        }
    }

    private void ChangeScorePlayer1(int value)
    {
        ScorePlayer1.text = value.ToString();
    }

    private void ChangeScorePlayer2(int value)
    {
        ScorePlayer2.text = value.ToString();
    }
}
