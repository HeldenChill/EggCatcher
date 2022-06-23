using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class CollideAction : MonoBehaviour
{
    private Collider2D[] detectedTargets;
    private ContactFilter2D contactFilter2D;
    void Start()
    {
        detectedTargets = new Collider2D[10];
        
    }

    public Collider2D[] CheckCollide(Collider2D detectCollider)
    {
        Array.Clear(detectedTargets, 0, detectedTargets.Length);
        int t = detectCollider.OverlapCollider(contactFilter2D, detectedTargets);
        return detectedTargets;
    }

    public void SetMask(string name)
    {
        contactFilter2D = new ContactFilter2D();
        contactFilter2D.layerMask = LayerMask.GetMask(name);
        contactFilter2D.useLayerMask = true;
        contactFilter2D.useTriggers = true;
    }
}
