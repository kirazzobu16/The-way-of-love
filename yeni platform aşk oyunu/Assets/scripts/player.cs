using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
public class player : MonoBehaviour
{
    [SerializeField] private LayerMask Groundslayermask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    public Animator animator;
    public ParticleSystem dust;

    
    private void Awake()
    {

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 5f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            CreateDust();
        }
        if (!IsGrounded())
        {
            animator.SetBool("IsJumping", true);
        }
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }
        HandleMovement();
    }



    private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, .1f, Groundslayermask);
        //Debug.Log(raycasthit2d.collider);
        return (raycasthit2d.collider != null);
        
    }
 
    private void HandleMovement()
    {
        float moveSpeed = 3f;
        float midAirControl = 1f;
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (IsGrounded())
            {    
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
                CreateDust();
            }
            else
            {
                rigidbody2d.velocity += new Vector2(-moveSpeed*midAirControl* Time.deltaTime, 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
            }
          
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {

                transform.localScale = new Vector3(1, 1, 1);
                if (IsGrounded())
                {   
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                    animator.SetFloat("Speed",Mathf.Abs (moveSpeed));
                    CreateDust();

                }
                else
                {
                    rigidbody2d.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
                }

            }
            else
            {
                animator.SetFloat("Speed", 0);
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }

        }
    }
 
    void CreateDust()
    {
        dust.Play();
    }
}