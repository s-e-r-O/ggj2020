using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public int secondsToDestroy;
    public float damage = 25f;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<Enemy>().Hurt(damage);
            Destroy(gameObject);
        }
    }
}
