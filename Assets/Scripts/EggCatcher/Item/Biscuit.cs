using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biscuit : AbstractItem
{
    private float tempTime = 0.1f;
    private float timeAccelerate = 0.1f;
    protected override void Start()
    {
        base.Start();
        tempTime = timeAccelerate;
    }

    protected virtual void Update()
    {
        if(tempTime <= 0)
        {
            speed += 1;
            rb.velocity = new Vector2(0, -speed);
            tempTime = timeAccelerate;
        }
        else
        {
            tempTime -= Time.deltaTime;
        }
    }
}
