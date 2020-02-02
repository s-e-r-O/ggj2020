using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public int secondsToDestroy;
    public float damageMin = 5f;
    public float damageMax = 10f;
    public float damageCriticMin = 30f;
    public float damageCriticMax = 40f;
    public float damageCriticPercentage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            ContactPoint2D contact = collision.contacts[0];
            bool isCritical = Random.Range(0f, 100f) <= damageCriticPercentage;
            float damage = isCritical ? Random.Range(damageCriticMin, damageCriticMax) : Random.Range(damageMin, damageMax);
            collision.gameObject.GetComponentInParent<Enemy>().Hurt(Mathf.Round(damage), contact.point, isCritical);
            Destroy(gameObject);
        }
    }
}
