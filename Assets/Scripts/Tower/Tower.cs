using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int tower;
    public int maxHealth = 100;
    private bool onRegenHealth;
    public AudioSource repair;
    public bool isdead;
    public int loseHealthDamage = 3;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            healthManager.ChangeTowerHealthBar(_health, tower);
        }
    }

    private int _health;
    private HealthManager healthManager;

    void Awake()
    {
        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
    }

    void Start()
    {
        Health = maxHealth;
        StartCoroutine(LoseHealth());
    }

    IEnumerator LoseHealth()
    {
        while (!isdead)
        {
            Damage(loseHealthDamage);
            yield return new WaitForSeconds(1);
        }
    }

    public void AddHealth(int value)
    {
        if (CanModifyHealth())
        {
            Health = Mathf.Min(Health + value, maxHealth);
            repair.Play();
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

    public bool CanModifyHealth()
    {
        return !isdead && Health <= maxHealth;
    }

    public void Die()
    {
        isdead = true;
        GameObject.Find("Master").GetComponent<Master>().AnnounceTowerDeath();
    }
}
