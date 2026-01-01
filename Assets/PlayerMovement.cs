using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Endtrigger endtrigger;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Animator animator;

    //For movement
    Vector2 movement;

    //For the sprite (the main character)
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //This was from the 1h30min tutorial
        if(movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }


    void FixedUpdate()
    {

        //nvm this kinda is important now
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //movement = new Vector3(movement.x, movement.y, 0);

        movement = new Vector3(x, y, 0);

    

        //Set direction of sprite to movement direction
        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        } else if (movement.x  > 0)
        {
            spriteRenderer.flipX = false;
        }

        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision player");
    }

}