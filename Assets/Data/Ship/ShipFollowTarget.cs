using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ShipMoverment
{
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetTargetPos();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        this.LoadTarget();
        base.LoadComponents();
    }

    protected override void ResetValue()
    {
        speed = 0.002f;
        minDistance = 5f;
        base.ResetValue();
    }

    protected void LoadTarget()
    {
        target = GameObject.Find("Ship").transform;
    }
    protected void GetTargetPos()
    {
        targetPos = this.target.position;
        targetPos.z = 0;
    }
}
