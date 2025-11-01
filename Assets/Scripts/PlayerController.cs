using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded = false;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rigidBody.linearVelocityX = Input.GetAxis("Horizontal") * speed;

            animator.SetBool("waliking", true);

            spriteRenderer.flipX = Input.GetAxis("Horizontal") * speed < 0;
        }
        else
            animator.SetBool("waliking", false);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rigidBody.AddForceY(jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D anotherObject)
    {
        if (anotherObject.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
            isGrounded = true;
    }
}