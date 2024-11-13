using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static string smoke1 = "Smoke_1";
    public static string impact1 = "Impact_1";
    public static string explosion1 = "Explosion_1";
    public static string explosion2 = "Explosion_2";
    public static FXSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        FXSpawner.instance = this;
    }
}
