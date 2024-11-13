using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    private List<GameObject> collidedObjects = new List<GameObject>();
    protected override void ResetValue()
    {
        damage = 10;
    }
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

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        bulletCtrl.BulletDeSpawn.DeSpawnObj();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!collidedObjects.Contains(other.gameObject))
        {

            collidedObjects.Add(other.gameObject);
            HandleCollision(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        collidedObjects.Remove(other.gameObject);
    }


    private void HandleCollision(GameObject collidedObject)
    {
        //if (collidedObject.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.DamageSender.Send(collidedObject.transform);
    }

    protected override string GetImpactFX()
    {
        return FXSpawner.explosion2;
    }
}
