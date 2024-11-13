using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : HauMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;

    public ItemDespawn ItemDespawn => itemDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) { return; }
        itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
    }

}
