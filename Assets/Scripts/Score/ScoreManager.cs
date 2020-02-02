using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScorePlayer1;
    public TextMeshProUGUI ScorePlayer2;

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
        ScorePlayer1.text = "x" + value.ToString();
    }

    private void ChangeScorePlayer2(int value)
    {
        ScorePlayer2.text = value.ToString() + "x";
    }
}
