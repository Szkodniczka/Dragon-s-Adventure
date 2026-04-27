using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool canMove = true;
    bool isFacingRight = true;
    public float moveSpeed = 5f;
    public Animator animator;
    


    [Header("Movement")]
    float horizontalMovement;



    [Header("Jumping")]
    public float horizontalJumpPower = 10f;
    public float verticalJumpPower = 20f;


    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

 


    void Update()
    {
        if (!canMove) return;
        //horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);


        Flip();



        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
        animator.SetFloat("xVelocity", rb.linearVelocity.x);

       
    }
    public void Move(InputAction.CallbackContext contex)
    {
        horizontalMovement = contex.ReadValue<Vector2>().x;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    public void Jump(InputAction.CallbackContext contex)
    {
        if (isGrounded())
        {
            if (contex.performed && rb.linearVelocity.magnitude > 10f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, horizontalJumpPower);
                animator.SetTrigger("jump");
            }
            if (contex.performed && rb.linearVelocity.x == 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalJumpPower);
                animator.SetTrigger("jumpVertical");
            }
            /*if (Input.GetButtonDown("Jump") && rb.velocity.x == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, verticalJumpPower);
                animator.SetTrigger("jumpVertical");
            }*/


        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
    
}
