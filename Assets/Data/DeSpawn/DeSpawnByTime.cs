using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByTime : DeSpawn
{
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected float timer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetTimer();
        
    }

    protected virtual void ResetTimer()
    {
        timer = 0f;
    }

    protected override bool CanDeSpawn()
    {
        timer += Time.fixedDeltaTime;
        return timer > delay;
    }
}
