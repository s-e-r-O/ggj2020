using UnityEngine;

public class Collector : MonoBehaviour
{
    private int items = 0;
    public bool player;

    public void AddScore()
    {
        items++;
        if (player)
        {
            ScoreManager.instance.ChangeScorePlayer1(items);
        }
        else
        {
            ScoreManager.instance.ChangeScorePlayer2(items);
        }
    }
}
