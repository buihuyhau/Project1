using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ShipMoverment
{
    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected void GetMousePos()
    {
        targetPos = InputManager.Instance.MouseWorldPos;
        targetPos.z = 0;
    }
}
