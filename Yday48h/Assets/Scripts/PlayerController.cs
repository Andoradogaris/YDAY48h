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

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
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
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, .05f);

        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0f, jumpForce));
            
        }
    }

    void TakeDamage(int damage)
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
