using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : HauMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) { return; }
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }
}
