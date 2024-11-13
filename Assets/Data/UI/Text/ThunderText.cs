using TMPro;
using UnityEngine;

public  class ThunderText : BaseText
{
    protected virtual void Update()
    {
        this.UpdateThunder();
    }

    protected virtual void UpdateThunder()
    {
        int hp = ShipCtrl.Instance.Inventory.thunder;
        this.text.SetText(hp.ToString());
    }
}

