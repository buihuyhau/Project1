using TMPro;
using UnityEngine;

public  class RocketText : BaseText
{
    protected virtual void Update()
    {
        this.UpdateRocket();
    }

    protected virtual void UpdateRocket()
    {
        int hp = ShipCtrl.Instance.Inventory.rocket;
        this.text.SetText(hp.ToString());
    }
}

