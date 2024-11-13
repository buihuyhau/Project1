using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : HauMonoBehaviour
{
    private static PlayerCtrl instance;
    [SerializeField] protected PlayerPickup playerPickup;
    [SerializeField] protected ShipCtrl currentShip;
    public static PlayerCtrl Instance => instance;
    public PlayerPickup PlayerPickup => playerPickup;
    public ShipCtrl CurrentShip => currentShip;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (playerPickup != null) return;
        playerPickup = transform.GetComponentInChildren<PlayerPickup>(); 
    }
}