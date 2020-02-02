using System;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public int RepairCost = 1;
    public int RepairHealthValue = 1;
    private PlayerInput input;
    private Player otherPlayer;
    private Player player;

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
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            otherPlayer = other.gameObject.GetComponent<Player>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            otherPlayer = null;
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
}
