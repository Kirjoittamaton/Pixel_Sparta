using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float speed = 8f;
    public float horizontal;
    private float vertical;
    public float jumpPower = 10f;
    public Rigidbody2D rb;
    public bool facingRight = true;
    public bool facingLeft = false;
    public float brakeJump = 1f;
    
    [Header("GroundCheck")]
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    [Header("Jump Buffer")]
    public float jumpBuffer = 0.5f;
    public float jumpBufferTimer;
    public bool jumpBufferOn = false;

    [Header("Coyote Time")]
    public float coyoteTime = 0.3f;
    public float coyoteTimer;

    [Header("Platform Checks")]
    public bool onJumpTPlatformCheck = false;
    public GameObject activeJTPlatform;

    public void Start()
    {
        jumpBufferOn = false;

    }

    public bool isGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && coyoteTimer > 0f)
        {
           // playerStart.position = transform.position;
            rb.AddForce(Vector2.up * jumpPower);
            //StartCoroutine("onLadders");
            jumpBufferTimer = jumpBuffer;
            jumpBufferOn = false;

        }


        /*
        if (context.performed )
        {
            jumpBufferTimer = jumpBuffer;
        }
        
        else if(context.performed && climbing)
        {
            
            rb.AddForce(Vector2.up * jumpPower);
            //cC.ScreenShake(3f,0.2f,4f);
            StartCoroutine("onLadders");
        }
        */


        if (context.canceled && rb.velocity.y > 0f)
        {
            jumpBuffer -= Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.4f);
            coyoteTimer = 0f;

        }



    }

    //public float vertical;


    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        if (context.performed)
        {
            //Walk();
        }

        if (context.canceled)
        {

            //Idle();
        }

    }

    public void Hit(InputAction.CallbackContext context)
    {


        if (isGrounded())
        {
            if(context.performed)
            {

            }
        }
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

   public void Update()
   {
        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);


        if (horizontal < -0.1f && facingRight)
        {
            Flip();
            facingLeft = true;
        }


        if (horizontal > 0.1f && !facingRight)
        {
            Flip();
            facingLeft = false;
        }


        if (horizontal == 0f && horizontal == 1f && facingRight)
        {
            facingLeft = false;
        }

        if (horizontal == 0f && horizontal == 1f && !facingRight && facingLeft)
        {
            facingLeft = false;
        }



        if (horizontal == -1f && !facingLeft)
        {
            facingLeft = true;
        }




        if (isGrounded())
        {
            coyoteTimer = coyoteTime;
            //anim.SetBool("isGrounded", true);
            //cameraTarget.posY = transform.position.y;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
           // anim.SetBool("isGrounded", false);
        }

        if (vertical < -0.1f && onJumpTPlatformCheck)
        {
            StartCoroutine("dropTPlatform");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JTPlatform"))
        {
            onJumpTPlatformCheck = true;
            //activeJTPlatform = collision.gameObject;
        }
    }
        public IEnumerator dropTPlatform()
    {
        activeJTPlatform.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        activeJTPlatform.GetComponent<Collider2D>().enabled = true;
        activeJTPlatform = null;
    }

}
