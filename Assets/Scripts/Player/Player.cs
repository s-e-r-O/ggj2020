using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int player;
    public int maxHealth = 100;
    public int maxItems = 100;
    public int Health { 
        get { return _health; } 
        set 
        { 
            _health = value; 
            healthManager.ChangeHealthBar(_health, player); 
        } 
    }
    public int Items
    {
        get { return _items; }
        set
        {
            _items = value;
            scoreManager.ChangeScore(_items, player);
        }
    }
    private int _items;
    private int _health;
    private ScoreManager scoreManager;
    private HealthManager healthManager;

    void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
    }

    void Start()
    {
        Health = maxHealth;
        Items = 0;
    }

    public void AddItems(int value = 1)
    {
        if (CanModifyItems(value))
        {
            Items = Mathf.Min(Items + value, maxItems);
        }
    }

    public void RemoveItems(int value = 1)
    {
        if (CanModifyItems())
        {
            Items -= value;
        }
    }

    public void AddHealth(int value)
    {
        if (CanModifyHealth())
        {
            Health = Mathf.Min(Health + value, maxHealth);
        }
    }

    public void Damage(int value)
    {
        Health = Mathf.Max(Health - value, 0);
        if (Health <= 0)
        {
            Die();
        }
    }

    public bool CanModifyItems(int value = 0)
    {
        return (Items + value) <= maxItems && (Items + value) >= 0;
    }
    public bool CanModifyHealth()
    {
        return Health <= maxHealth;
    }

    public void Die()
    {
        Debug.Log($" {player}: You are dead");
    }
}
