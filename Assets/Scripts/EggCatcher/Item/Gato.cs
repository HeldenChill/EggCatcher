using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : AbstractItem
{
    private float tempTime = 0.1f;
    private float timeChangeDirection = 0.1f;
    protected virtual void Update()
    {
        if (tempTime <= 0)
        {
            speed += 0.8f;
            Vector2 direction = GetDirection();
            rb.velocity = new Vector2(direction.x * speed, -direction.y * speed);
            tempTime = timeChangeDirection;
        }
        else
        {
            tempTime -= Time.deltaTime;
        }
    }

    protected Vector2 GetDirection()
    {
        float x = Random.Range(-0.8f, 0.8f);
        float y = 1 - x;
        return new Vector2(x, y).normalized;
    }
}
