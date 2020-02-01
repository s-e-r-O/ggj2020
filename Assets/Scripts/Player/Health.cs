using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 100;
    private int max = 100;
    public bool player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            if(health > 0)
            {
                health -= 10;
            }
            if (player)
            {
                HealthManager.instance.ChangeHealthBar1(health);
            }
            //else
            //{
            //    HealthManager.instance.ChangeHealthBar2(health);
            //}
            Destroy(other.gameObject);
        }
    }
}
