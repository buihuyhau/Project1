using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public abstract class DamageReceiver : HauMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected bool isDead = false;

    public int HP => hp;
    public int HPMax => hpMax;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (sphereCollider != null) { return; }
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.4f;
    }
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    public virtual void Reborn()
    {
        hp = hpMax;
        isDead = false;
    }

    public virtual void Add(int add)
    {
        hp += add;
        if(this.hp > hpMax) hp = hpMax;
    }

    public virtual void Deduct(int deduct) 
    {
        if(isDead) return;
        hp -= deduct;
        if (this.hp < 0) hp = 0;
        CheckIsDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }

    protected abstract void OnDead();

}
