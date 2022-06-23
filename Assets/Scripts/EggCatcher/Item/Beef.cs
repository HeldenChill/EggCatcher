using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beef : AbstractItem
{
    private float tempTime = 0.1f;
    private float timeStop = 0.1f;
    private float directionParam;
    private float direction;

    private void OnEnable()
    {
        direction = Mathf.Sqrt(2) / 2f;
        directionParam = direction;
    }
    protected virtual void Update()
    {
        if (tempTime <= 0)
        {
            speed *= 1.1f;
            rb.velocity = new Vector2(directionParam * speed, -direction * speed);
            directionParam = -directionParam;
            tempTime = timeStop;
        }
        else
        {
            tempTime -= Time.deltaTime;
        }
    }
}
