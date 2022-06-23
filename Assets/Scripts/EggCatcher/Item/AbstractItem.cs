using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItem : MonoBehaviour,IHaveScore
{
    [SerializeField]
    protected int score;
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float speedNoise = 1f;
    
    protected virtual void Start()
    {
        speed += Random.Range(-speedNoise, speedNoise);
        rb.velocity = new Vector2(0, -speed);
    }

    public int GetScore()
    {
        return score;
    }

}
