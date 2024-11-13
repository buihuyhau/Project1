using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeSpawn : HauMonoBehaviour
{

    protected virtual void FixedUpdate()
    {
        DeSpawning();
    }

    protected virtual void DeSpawning()
    {
        if (!CanDeSpawn()) return;
        DeSpawnObj();
    }
    public virtual void DeSpawnObj()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDeSpawn();

}
