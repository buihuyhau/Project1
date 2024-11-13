using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{

    protected override void OnEnable()
    {
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCam.transform.position;
        Vector3 objPos = transform.parent.position;
        camPos.x += Random.Range(-7, 7);
        camPos.y += Random.Range(-7, 7);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0F, 0F, rot_z);
    }
}
