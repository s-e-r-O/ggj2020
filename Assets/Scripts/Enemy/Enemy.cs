using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public GameObject itemPrefab;
    public int numberOfItems = 3;
    public float itemForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(float damage)
    {
        health = Mathf.Max(health-damage, 0);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            GameObject item = Instantiate(itemPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

            Vector2 force = new Vector2(Random.Range(-1f, 1f), Random.Range(0.3f, 1f)) * itemForce;
            
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
}
