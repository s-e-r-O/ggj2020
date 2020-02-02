using System;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public int RepairCost = 1;
    private PlayerInput input;
    private GameObject player;

    void Start()
    {
        input = GetComponentInParent<PlayerInput>();
    }

    void Update()
    {
        if (player != null && input.GetRepair())
        {
            RepairPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = null;
        }
    }

    private void RepairPlayer()
    {
        var collector = player.GetComponent<Collector>();
        var health = player.GetComponent<Health>();
        if (collector.Items >= RepairCost && health.CanAdd(RepairCost))
        {
            collector.Items -= RepairCost;
            health.AddPoints(RepairCost);
        }
    }
}
