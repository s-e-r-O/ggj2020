using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 100;
    private int max = 100;
    private int min = 0;
    public bool player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            ChangeHealth(-10);
            Destroy(other.gameObject);
        }
    }

    private void ChangeHealth(int value)
    {
        if ((health+value) <= max && (health + value) >= min)
        {
            health += value;
            if (player)
            {
                HealthManager.instance.ChangeHealthBar1(health);
            }
            else
            {
                HealthManager.instance.ChangeHealthBar2(health);
            }
        }
    }
}
