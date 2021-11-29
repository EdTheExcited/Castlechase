
using System.Runtime.InteropServices;
using System.ComponentModel;
using System;
using UnityEngine;
using Unity;

public class MovementScirpt : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private bool isGrounded; //kollar om spelaren är grounded, alltså står på mark
    public Transform feetPos; //gör en transform som heter feetpos, som andvänds för att lagra x,y av spelarens fötter
    public float checkRadius; //kollar x,y på radius av feetpos circle
    public LayerMask whatIsGround; //en variabel som bestämmer vilket lager som räknas som mark.
    public float jumpForce; //avgör hur kraftigt gubben hoppar 
    private float jumpTimeCounter; //räknar hur länge gubben varit i luften
    public float jumpTime;
    private bool inAir; //kollar om man är i luften
    public Vector2 startPos;

    private Animator animator;
    private SpriteRenderer renderer;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();


    }
    private void Start()
    {
        startPos = body.position;
    }
    public void Reset()
    {
        body.position = startPos;
    }
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        Jump();


        renderer.flipX = body.velocity.x < 0;
        if (isGrounded == false)
        {
            animator.Play("Jump");
        }

        else if (body.velocity.x != 0 && isGrounded == true)
        {
            animator.Play("Running");
        }
        else
        {
            animator.Play("Idle");
        }



    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = body.velocity;

            velocity.y = jumpForce;

            body.velocity = velocity;

            // body.velocity = Vector2.up * jumpForce;
            inAir = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && inAir == true)
        {
            if (jumpTimeCounter > 0)
            {
                Vector3 velocity = body.velocity;

                velocity.y = jumpForce;

                body.velocity = velocity;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                inAir = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            inAir = false;
        }

    }
}
