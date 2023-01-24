using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    UIManager uiManager;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private bool isJumping;
    private bool isGrounded = true;

    [SerializeField]
    private Transform groundCheckLeft;
    [SerializeField]
    private Transform groundCheckRigth;
    private Rigidbody2D rb;

    [Header("Stats")]
    public int health;
    [SerializeField]
    private int maxHealth;

    private bool isDead;

    [Header("Animation")]
    Animator anim;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRigth.position);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

    }

    void FixedUpdate() 
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePLayer(horizontalMovement);
    }


    void MovePLayer(float _horizontalMovement)
    {
        if(_horizontalMovement != 0)
        {
            if(_horizontalMovement > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(_horizontalMovement < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, .05f);

        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0f, jumpForce * 4));
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        uiManager.GoToMenu();
    }
}
