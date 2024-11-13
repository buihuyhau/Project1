using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByDistance : DeSpawn
{
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera mainCam;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCam();
    }

    protected virtual void LoadCam()
    {
        if (mainCam != null) { return; }
        mainCam = Transform.FindObjectOfType<Camera>();
    }

    protected override bool CanDeSpawn()
    {
        distance = Vector3.Distance(transform.position, mainCam.transform.position);
        return distance > disLimit;
    }
}
