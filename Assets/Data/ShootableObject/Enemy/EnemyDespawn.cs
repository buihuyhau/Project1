using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DeSpawnByDistance
{
    public override void DeSpawnObj()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
