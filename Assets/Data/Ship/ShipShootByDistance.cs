using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDistance : ShipShooting
{
    [Header("Shoot by Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 6f;

    protected override void LoadComponents()
    {
        this.LoadTarget();
        base.LoadComponents();
    }

    protected override void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShootingBullet) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet2, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }
    protected void LoadTarget()
    {
        target = GameObject.Find("Ship").transform;
    }

    protected override void ResetValue()
    {
         shootDelay = 1.5f;
    }

    protected override void IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isShootingBullet = this.distance < this.shootDistance;
    }
}
