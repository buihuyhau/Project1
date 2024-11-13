using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : HauMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected DeSpawn despawn;
    [SerializeField] protected ShootableObjectSO shootableObject;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    public Transform Model  => model;
    public DeSpawn Despawn => despawn;
    public ShootableObjectSO ShootableObject  => shootableObject;
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadShootableObjectSO();
        this.LoadSpawner();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (despawn != null) { return; }
        despawn = transform.GetComponentInChildren<DeSpawn>();
    }

    protected virtual void LoadModel()
    {
        if (model != null) { return; }
        model = transform.Find("Model");
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (shootableObject != null) { return; }
        string resPath = "ShootableObject/" + GetObjectTypeString() +"/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
    }
    protected abstract string GetObjectTypeString();
}
