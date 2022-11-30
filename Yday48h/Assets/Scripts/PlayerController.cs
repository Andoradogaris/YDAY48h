using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private Transform groundCheckLeft;
    [SerializeField]
    private Transform groundCheckRigth;

    [SerializeField]
    private Rigidbody2D rb;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRigth.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePLayer(horizontalMovement);
    }

    void MovePLayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, .05f);

        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0f, jumpForce));
            
        }
    }
}
