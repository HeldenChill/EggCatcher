using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public static Action<int> OnAddScore;
    public Rigidbody2D rb;
    public float speed = 3;
    public CollideAction collideAction;
    public Collider2D detectCollider;

    bool gameEnd = false;
    private void Start()
    {
        collideAction.SetMask("Item");
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void FixedUpdate()
    {
        if (gameEnd) return;

        float x = Input.GetAxis("Horizontal");
        bool isNotOverLeft = gameObject.transform.position.x > GameManager.inst.BeginPosGeneratorEgg.position.x + 1;
        bool isNotOverRight = gameObject.transform.position.x < GameManager.inst.EndPosGeneratorEgg.position.x - 1;

        if ((x < 0 && isNotOverLeft) || (x > 0 && isNotOverRight))
        {
            rb.velocity = new Vector2(x * Time.fixedDeltaTime * speed * 60, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        Collider2D[] colliders = collideAction.CheckCollide(detectCollider);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i] != null)
            {
                int score = colliders[i].gameObject.GetComponent<IHaveScore>().GetScore();

                Destroy(colliders[i].gameObject);
                OnAddScore?.Invoke(score);
            }
        }
    }

    private void OnGameEnd()
    {
        gameEnd = true;
        rb.velocity = Vector2.zero;
    }


    private void OnDisable()
    {
        GameManager.OnGameEnd -= OnGameEnd;
    }
}
