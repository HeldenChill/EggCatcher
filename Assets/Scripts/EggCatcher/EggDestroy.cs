using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EggDestroy : MonoBehaviour
{
    public CollideAction collideAction;
    public Collider2D dectectCollider;

    private void Start()
    {
        collideAction.SetMask("Item");
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] detectedTargets = collideAction.CheckCollide(dectectCollider);
        for(int i = 0; i < detectedTargets.Length; i++)
        {
            if(detectedTargets[i] != null)
            {
                Destroy(detectedTargets[i].gameObject);
            }
        }
    }
}
