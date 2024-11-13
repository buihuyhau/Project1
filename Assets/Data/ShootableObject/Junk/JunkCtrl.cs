using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : HauMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;
    [SerializeField] protected ShootableObjectSO shootableObject;
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender  => damageSender; 

    public Transform Model => model; 
    public JunkDespawn JunkDespawm => junkDespawn; 
    public ShootableObjectSO ShootableObjectSO => shootableObject; 


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadJunkSO();
        LoadDamageSender();
    }
    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) { return; }
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
    }
    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) { return; }
        damageSender = transform.GetComponentInChildren<DamageSender>();
    }

    protected virtual void LoadModel()
    {
        if (model != null) { return; }
        model = transform.Find("Model");
    }
    protected virtual void LoadJunkSO()
    {
        if (shootableObject != null) { return; }
        string resPath = "ShootableObject/Junk/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
    }
}
