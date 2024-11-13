using TMPro;
using UnityEngine;

public  class OreText : BaseText
{
    protected virtual void Update()
    {
        this.UpdateOre ();
    }

    protected virtual void UpdateOre()
    {
        int hp = ShipCtrl.Instance.Inventory.ore;
        this.text.SetText(hp.ToString());
    }
}

