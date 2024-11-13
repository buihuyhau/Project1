using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;
    [SerializeField] protected Rigidbody _rigidbody;

    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
        LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) { return; }
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    protected override void OnDead()
    {
        junkCtrl.JunkDespawm.DeSpawnObj();
        Reborn();
        OnDeadFX();
        DropDeadDrop();
        AudioManager.Instance.PlaySFX("explonsion1");

    }


    protected virtual void DropDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);  
    }

    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void Reborn()
    {
        hpMax = junkCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {

        this.JunkCtrl.DamageSender.Send(other.transform);
    }
}
