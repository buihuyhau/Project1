using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouseAndKey : ShipShooting
{
    [SerializeField] protected bool isShootingRocket = false;
    [SerializeField] protected bool isShootingThunder = false;


    protected override void IsShooting()
    {
        isShootingBullet = InputManager.Instance.OnFiringBullet == 1;
        isShootingRocket = InputManager.Instance.OnFiringRocket;
        isShootingThunder = InputManager.Instance.OnFiringThunder;
    }

    protected override void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (this.isShootingBullet) 
        {
            if (this.shootTimer < this.shootDelay) return;
            this.shootTimer = 0;

            Vector3 spawnPos = transform.position;
            Quaternion rotation = transform.parent.rotation;
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet1, spawnPos, rotation);
            AudioManager.Instance.PlaySFX("shotter");

            if (newBullet == null) return;

            newBullet.gameObject.SetActive(true);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShotter(transform.parent);
        }
        if (this.isShootingRocket) 
        {
            if (this.shootTimer < this.shootDelay) return;
            if (ShipCtrl.Instance.Inventory.rocket == 0) return;
            this.shootTimer = 0;

            Vector3 spawnPos = transform.position;
            Quaternion rotation = transform.parent.rotation;
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.rocket, spawnPos, rotation);
            if (newBullet == null) return;

            newBullet.gameObject.SetActive(true);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShotter(transform.parent);
            ShipCtrl.Instance.Inventory.rocket--;
        }
        
        if (this.isShootingThunder) 
        {
            if (this.shootTimer < this.shootDelay) return;
            this.shootTimer = 0;

            Vector3 spawnPos = transform.position;
            Quaternion rotation = transform.parent.rotation;
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.thunder, spawnPos, rotation);
            if (newBullet == null) return;

            newBullet.gameObject.SetActive(true);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShotter(transform.parent);
        }
        

    }
}
