using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScorePlayer1;
    public TextMeshProUGUI ScorePlayer2;

    public void ChangeScorePlayer1(int value)
    {
        ScorePlayer1.text = "x" + value.ToString();
    }

    public void ChangeScorePlayer2(int value)
    {
        ScorePlayer2.text = value.ToString() + "x";
    }
}
