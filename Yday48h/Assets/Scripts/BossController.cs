using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    [Header("Attack 1")]
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    [SerializeField]
    private int movePosition;
    [SerializeField]
    private float moveTime;


    void Update() 
    {
        Move();
    }

    void Move() 
    {
        if(movePosition >= 0 && movePosition <= 2)
        {
            transform.DOMove(positions[movePosition].position, moveTime);
        }
    }
}
