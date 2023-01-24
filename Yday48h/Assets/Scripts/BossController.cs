using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    

    [Header("Attack 1")]
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    [SerializeField]
    private float moveTime;
    [SerializeField]
    GameObject laserObject;
    [SerializeField]
    Transform laserPos;

    [SerializeField]
    float attack1Time;

    [Header("Stats")]
    public int health;
    [SerializeField]
    private int maxHealth;

    private bool canAttack = true;

    void Awake() 
    {
        health = maxHealth; 
        anim.SetInteger("Attack", 0);
    }

    void Update()
    {
        if(canAttack)
        {
            RandomAttack();
        }
    }

    IEnumerator Attack1()
    {
        int i = 0;
        for(i = 0; i < 3; i++)
        {
            transform.DOMove(positions[Random.Range(0, positions.Count)].transform.position, moveTime);
            anim.SetInteger("Attack", 1);
            yield return new WaitForSeconds(attack1Time);
            Instantiate(laserObject, laserPos.position, laserPos.rotation);
            anim.SetInteger("Attack", 0);
        }
        i  = 0;
    }

    void Attack2()
    {
        
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(attack1Time + moveTime);
        transform.DOMove(positions[1].transform.position, moveTime);
        yield return new WaitForSeconds(3f);
        canAttack = true;
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

    void RandomAttack()
    {
        canAttack = false;
        int rdmAttack = Random.Range(0, 1);
        if(rdmAttack == 0)
        {
            StartCoroutine(Attack1());
        }

        StartCoroutine(Idle());
    }
}
