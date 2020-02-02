using UnityEngine;

public class Repair : MonoBehaviour
{
    public int RepairCost = 1;
    public int RepairHealthValue = 1;
    private PlayerInput input;
    private Player player;
    private Player otherPlayer;
    private Tower tower;

    void Start()
    {
        input = GetComponentInParent<PlayerInput>();
        player = GetComponentInParent<Player>();
    }

    void Update()
    {
        if (otherPlayer != null && input.GetRepair())
        {
            RepairPlayer();
        }else if (tower != null && input.GetRepair())
        {
            RepairTower();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            otherPlayer = other.gameObject.GetComponent<Player>();
        }
        else if (other.gameObject.tag == "Tower")
        {
            tower = other.gameObject.GetComponent<Tower>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            otherPlayer = null;
        }
        else if (other.gameObject.tag == "Tower")
        {
            tower = null;
        }
    }

    private void RepairPlayer()
    {
        if (player.CanModifyItems(-RepairCost) && otherPlayer.CanModifyHealth())
        {
            player.RemoveItems(RepairCost);
            otherPlayer.AddHealth(RepairHealthValue);
        }
    }

    private void RepairTower()
    {
        if (player.CanModifyItems(-RepairCost) && tower.CanModifyHealth())
        {
            player.RemoveItems(RepairCost);
            tower.AddHealth(RepairHealthValue);
        }
    }
}
