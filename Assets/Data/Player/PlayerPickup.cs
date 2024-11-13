using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable) 
    {
        string itemName = itemPickupable.GetItemName();
        if (playerCtrl.CurrentShip.Inventory.AddItem(itemName, 1))
        {
            itemPickupable.Picked();
        }
    }
}
