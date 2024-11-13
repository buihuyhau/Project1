using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HauMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    [SerializeField] protected BulletDeSpawn bulletDeSpawn ;

    public DamageSender DamageSender { get => damageSender; }
    public BulletDeSpawn BulletDeSpawn { get => bulletDeSpawn; }
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageSender();
        LoadBulletDeSpawn();
    }
    protected virtual void LoadBulletDeSpawn()
    {
        if (bulletDeSpawn != null) { return; }
        bulletDeSpawn = transform.GetComponentInChildren<BulletDeSpawn>();
    }
    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) { return; }
        damageSender = transform.GetComponentInChildren<DamageSender>();
    }
    public virtual void SetShotter(Transform shooter)
    {
        this.shooter = shooter;
    }

}
