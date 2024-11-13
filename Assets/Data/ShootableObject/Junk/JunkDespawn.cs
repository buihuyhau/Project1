using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DeSpawnByDistance
{
    public override void DeSpawnObj()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
}
