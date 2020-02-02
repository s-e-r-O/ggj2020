using UnityEngine;

public class Health : MonoBehaviour
{
    public int Points { get; set; }
    public int Max = 100;
    public int Min = 0;
    public bool player;
    public HealthManager healthManager;

    void Start()
    {
        Points = 50;
        ChangeHealthBar();
    }

    public void AddPoints(int value)
    {
        if (CanAdd(value))
        {
            Points += value;
            ChangeHealthBar();
        }
    }

    public bool CanAdd(int value)
    {
        return (Points + value) <= Max && (Points + value) >= Min;
    }

    public void ChangeHealthBar()
    {
        if (player)
        {
            healthManager.ChangeHealthBar1(Points);
        }
        else
        {
            healthManager.ChangeHealthBar2(Points);
        }
    }
}
