using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : HauMonoBehaviour
{

    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (itemCtrl != null) { return; }
        itemCtrl = transform.parent.GetComponent<ItemCtrl>();
    }
}
