using TMPro;
using UnityEngine;

public  class HeartText : BaseText
{
    protected virtual void Update()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        int hp = ShipCtrl.Instance.DamageReceiver.HP;
        this.text.SetText(hp.ToString());
    }
}

