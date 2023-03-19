using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D coll;
    Animator anim;
    float hInput;
    bool isJumped = false;
    bool isFlipped = false;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;

    private enum MovementState { idle,running,jump,fall,idleShoot,runShoot,jumpShoot}
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //taking input for plalyer jump

        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            isJumped= true;
        }else if (Input.GetKeyDown(KeyCode.Space) && isJumped)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            isJumped= false;
        }


        // taking input for player movement horizontally

        hInput = Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(hInput*moveSpeed, rb.velocity.y);


        //flipping the player according to the input

        if (rb.velocity.x >=0.1f&&isFlipped)
        {
            transform.Rotate(0, 180, 0);
            isFlipped= false;
        }
        else if(rb.velocity.x <=-0.1f&&!isFlipped)
        {
            transform.Rotate(0, 180, 0);
            isFlipped= true;
        }
        PlayerAnimation();

    }
    

    //PlayerAnimation is for animation of the player movement
    private void PlayerAnimation()
    {
        MovementState state;
        if (rb.velocity.x == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                state = MovementState.idleShoot;
            }
            else
            {
                state = MovementState.idle;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                state = MovementState.runShoot;
            }
            else
            {
                state = MovementState.running;
            }
            
        }
        if (rb.velocity.y > 1f)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                state = MovementState.jumpShoot;
            }
            else
            {
                state = MovementState.jump;
            }
            
        }
        if (rb.velocity.y < -1f)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                state = MovementState.jumpShoot;
            }
            else
            {
                state = MovementState.fall;
            }
        }


        anim.SetInteger("State",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
