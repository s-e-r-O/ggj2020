using UnityEngine;

public class Collector : MonoBehaviour
{
    private int items = 0;
    public bool player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Items"))
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
            Destroy(other.gameObject);
        }
    }
}
