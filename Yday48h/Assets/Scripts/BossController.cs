using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    Animator anim;

    [Header("Attack 1")]
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    [SerializeField]
    private int movePosition;
    [SerializeField]
    private float moveTime;

    [Header("Stats")]
    public int health;
    [SerializeField]
    private int maxHealth;

    private bool canAttack = true;

    void Awake() 
    {
        health = maxHealth; 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(canAttack)
        {
            StartCoroutine(RandomAttack());
        }
    }

    void Attack1()
    {
        
    }

    void Attack2()
    {
        
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
        Debug.Log("isDied");
    }

    IEnumerator RandomAttack()
    {
        yield return new WaitForSeconds(0f);
    }
}
