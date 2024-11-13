using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Fly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        moveSpeed = 4f;
    }
}
