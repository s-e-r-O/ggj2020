using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision coll;
    private WeaponHolder weaponHolder;
    private PlayerInput input;
    private SpriteRenderer sr;
    private Animator anim;

    [Header("Stats")]

    public float speed = 30f;
    public float jumpForce = 30f;

    private bool facingRight = true;
    private float deadZoneToFlip = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        weaponHolder = GetComponent<WeaponHolder>();
        input = GetComponent<PlayerInput>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = input.GetMovement();
        Walk(dir);
        if (input.GetJumpDown())
        {
            if (coll.onGround)
            {
                Jump(Vector2.up);
            }
        }
        anim.SetFloat("HorizontalMovement", coll.onGround? rb.velocity.x / speed : 0f);
        anim.SetBool("IsGround", coll.onGround);
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
        if (dir.x > deadZoneToFlip)
        {
            facingRight = true;
            sr.flipX = false;
            if (coll.onRightWall)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        if (dir.x < -deadZoneToFlip)
        {
            facingRight = false;
            sr.flipX = true;
            if (coll.onLeftWall)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        weaponHolder.Flip(facingRight);

    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
        
    }
}
