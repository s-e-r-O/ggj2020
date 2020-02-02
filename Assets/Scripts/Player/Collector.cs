using UnityEngine;

public class Collector : MonoBehaviour
{
    public int Items { set; get; } = 0;
    public bool player;
    public ScoreManager scoreManager;

    void Start()
    {
        Items = 100;
        ChangeScore();
    }

    public void AddScore()
    {
        Items++;
        ChangeScore();
    }

    public void ChangeScore()
    {
        if (player)
        {
            scoreManager.ChangeScorePlayer1(Items);
        }
        else
        {
            scoreManager.ChangeScorePlayer2(Items);
        }
    }
}
