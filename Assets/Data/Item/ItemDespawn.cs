using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DeSpawnByDistance
{
    public override void DeSpawnObj()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
