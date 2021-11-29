using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform secondSpawnPoint;

    [SerializeField] Transform secondSpawnLimit;

    Vector3 startPoint;
    private Rigidbody2D body;
    public float jumpForce;
    private bool dontJumpRight;
    private bool dontJumpLeft;
    private bool dontHopRight;
    private bool dontHopLeft;
    public Transform feetPos;
    public Transform lowerRight;
    public Transform lowerLeft;
    public Transform rightCollider;
    public Transform leftCollider;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public float checkRadius;
    public float checkRadiusz;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool inAir;

    public float speed;
    public float maxSpeed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPoint = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = target.position - transform.position;
        Vector3 velocity = body.velocity;
        if (diff.x > 0)
        {
            body.AddForce(Vector2.right * speed);
            // velocity.x = speed;
        }
        else
        {
            body.AddForce(Vector2.left * speed);
            // velocity.x = -speed;
        }
        body.velocity = new Vector2(Mathf.Clamp(velocity.x, maxSpeed * -1, maxSpeed), velocity.y);
        print(velocity);
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (ShouldJump())
        {
            Jump();
        }
    }

    public void Reset()
    {
        if (body.position.x >= secondSpawnLimit.position.x)
        {
            // Vector2 respawn2 = new Vector2(86, -3);
            transform.position = secondSpawnPoint.position;
        }
        else
        {
            transform.position = startPoint;
        }

        body.velocity = new Vector2(0, 0);
    }

    private bool ShouldJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        dontJumpRight = Physics2D.OverlapCircle(lowerRight.position, checkRadius, whatIsGround);
        dontJumpLeft = Physics2D.OverlapCircle(lowerLeft.position, checkRadius, whatIsGround);
        dontHopRight = Physics2D.OverlapCircle(rightCollider.position, checkRadiusz, whatIsGround);
        dontHopLeft = Physics2D.OverlapCircle(leftCollider.position, checkRadiusz, whatIsGround);

        if (body.velocity.x > 0)
        {
            if (isGrounded && !dontJumpRight || isGrounded && dontHopRight)
            {
                return true;
            }

        }
        else if (body.velocity.x < 0)
        {
            if (isGrounded && !dontJumpLeft || isGrounded && dontHopLeft)
            {
                return true;
            }
        }
        return false;
    }




    private void Jump()
    {


        body.AddForce(new Vector2(0, jumpForce));
        print("JUMP MOTHERFUDGER!");




        // if (!isGrounded && inAir == true)
        // {
        //     if (jumpTimeCounter > 0)
        //     {
        //         Vector3 velocity = body.velocity;

        //         velocity.y = jumpForce;

        //         body.velocity = velocity;
        //         jumpTimeCounter -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         inAir = false;
        //     }
        // }
        // if (isGrounded)
        // {
        //     inAir = false;
        // }
    }
}
