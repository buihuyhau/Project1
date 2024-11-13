using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoverment : HauMonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.05f;
    [SerializeField] protected float minDistance = 1f;
    [SerializeField] protected float distance = 1f;
    protected virtual void FixedUpdate()
    {
        LookAtTarget();
        Moving();
    }

    protected void LookAtTarget()
    {
        Vector3 diff = targetPos - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0F, 0F, rot_z);
    }
    protected void Moving()
    {
        distance = Vector3.Distance(transform.parent.position, targetPos);
        if (distance <= minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, speed);
        transform.parent.position = newPos;
    }
}
