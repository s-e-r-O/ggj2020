using DG.Tweening;
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
    public bool isInvincible;
    public float invincibilityTime = 2f;
    public bool inDamage;

    Sequence seq;
    PlayerMovement pm;

    private int _items;
    private int _health;
    private ScoreManager scoreManager;
    private HealthManager healthManager;
    private SpriteRenderer sr;
    private ParticleSystem pr;

    void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
        sr = GetComponentInChildren<SpriteRenderer>();
        pm = GetComponent<PlayerMovement>();
        pr = GetComponentInChildren<ParticleSystem>();
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
            if (inDamage && Health > maxHealth/4)
            {
                inDamage = false;
                pr.Stop();
            }
        }
    }

    public void Damage(int value)
    {
        if (!isInvincible)
        {
            Health = Mathf.Max(Health - value, 0);

            if (Health <= 0)
            {
                Die();
            }
            else
            {
                if (!inDamage && Health <= maxHealth / 4)
                {
                    inDamage = true;
                    pr.Play();
                }
                pm.Push();
                isInvincible = true;
                seq = DOTween.Sequence();
                seq.Append(sr.DOFade(0.5f, invincibilityTime / 8f));
                seq.Append(sr.DOFade(1f, invincibilityTime / 8f));
                seq.SetLoops(8);
                seq.Play();
                StartCoroutine(Invincbility());

            }

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

    public IEnumerator Invincbility()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
        seq.Kill();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
    }
}
