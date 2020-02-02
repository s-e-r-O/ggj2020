using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public List<GameObject> itemPrefabs;
    public GameObject textPrefab;
    public int numberOfItems = 3;
    public float itemForce = 10f;
    public AudioSource explosion;
    public float TTL = 60f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TTL);
    }

    public void Hurt(float damage, Vector2 position, bool isCritical)
    {
        var text = Instantiate(textPrefab, position, Quaternion.identity);
        var mesh = text.GetComponent<TextMesh>();
        mesh.text = damage.ToString();
        if (isCritical)
        {
            mesh.color = Color.red;
        }

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
            int index = Random.Range(0, itemPrefabs.Count);
            Quaternion rotation = Random.rotation;
            rotation.x = 0;
            rotation.y = 0; 
            GameObject item = Instantiate(itemPrefabs[index], transform.position, rotation);
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            SpriteRenderer sr = item.GetComponentInChildren<SpriteRenderer>();
            sr.flipX = Random.Range(0, 2) == 0;
            Vector2 force = new Vector2(Random.Range(-1f, 1f), Random.Range(0.3f, 1f)) * itemForce;
            
            rb.AddForce(force);
        }
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        explosion.Play();
        Destroy(gameObject);
    }
}
