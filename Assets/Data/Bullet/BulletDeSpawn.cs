using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeSpawn : DeSpawnByDistance
{
    public override void DeSpawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }

}
