using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : HauMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected SpawnPoints spawnPoints;

    public Spawner JunkSpawner { get => spawner; }
    public SpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawmer();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawmer()
    {
        if (spawner != null) { return; }
        spawner = GetComponent<Spawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) { return; }
        spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
    }
}
