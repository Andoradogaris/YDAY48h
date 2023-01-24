using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Laser : MonoBehaviour
{
    [SerializeField]
    float moveTime;
    [SerializeField]
    int damage;

    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x - 30, transform.position.y, transform.position.z), moveTime);
        StartCoroutine(Destroy());
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject, 0.05f);
        }    
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(moveTime);
        Destroy(gameObject);
    }
}
