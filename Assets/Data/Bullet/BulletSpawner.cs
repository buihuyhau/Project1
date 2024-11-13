using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static string bullet1 = "Bullet_1";
    public static string bullet2 = "Bullet_2";
    public static string rocket = "Rocket";
    public static string thunder = "Thunder";
    public static BulletSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        BulletSpawner.instance = this;
    }
}
