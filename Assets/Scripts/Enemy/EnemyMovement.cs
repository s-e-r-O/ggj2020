using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction = Vector2.right;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.flipX = direction.x > 0;
        part = GetComponentInChildren<ParticleSystem>();
        var shape = part.shape;
        shape.rotation = new Vector3(part.shape.rotation.x, direction.x > 0 ? -90 : 90, part.shape.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
}
