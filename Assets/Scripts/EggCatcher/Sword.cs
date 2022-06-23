using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speedNoise = 1f;
    void Start()
    {
        rb.velocity = transform.right * (speed + Random.Range(-speedNoise, speedNoise));
    }
}
