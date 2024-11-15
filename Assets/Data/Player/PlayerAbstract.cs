using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : HauMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) { return; }
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
}
