using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRandom : HauMonoBehaviour
{
    [SerializeField] protected SpawnCtrl spawnCtrl;
    [SerializeField] protected float randomDelay = 2f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (spawnCtrl != null) { return; }
        spawnCtrl = GetComponent<SpawnCtrl>();
    }

    private void FixedUpdate()
    {
        JunkSpawning();      
    }
    
    protected virtual void JunkSpawning()
    {
        if (RandomReachLimit()) return;

        randomTimer += Time.fixedDeltaTime;
        if (randomTimer < randomDelay) return;
        randomTimer = 0f;

        Transform ranPoint = spawnCtrl.SpawnPoints.GetRandom();
        Vector3 pos = spawnCtrl.SpawnPoints.GetRandom().position;
        Quaternion rot = transform.rotation;

        Transform prefab = spawnCtrl.JunkSpawner.RandomPrefab();
        Transform obj = spawnCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = spawnCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= randomLimit;
    }
}
