using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JunkDamageSender : DamageSender
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl => junkCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        LoadJunkCtrl();

    }


    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) { return; }
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        DestroyJunk();
    }

    protected virtual void DestroyJunk()
    {
        junkCtrl.JunkDespawm.DeSpawnObj();
    }


    protected virtual void OnTriggerEnter(Collider other)
    {

        this.JunkCtrl.DamageSender.Send(other.transform);
    }
}
