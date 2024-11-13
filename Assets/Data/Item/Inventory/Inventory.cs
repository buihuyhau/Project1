using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : HauMonoBehaviour
{
    [SerializeField] public int ore = 0;
    [SerializeField] public int repaitBox = 0;
    [SerializeField] public int rocket = 1;
    [SerializeField] public int thunder = 0;
    public virtual bool AddItem(string itemName, int addCount)
    {
        switch (itemName)
        {
            case "IronOre": ore++;
                break;
            case "GoldOre": ore++;
                break;
            case "CopperOre": ore++;
                break;
            case "RepairBoxItem":
                if (ShipCtrl.Instance.DamageReceiver.HP < 5)
                {
                    ShipCtrl.Instance.DamageReceiver.Add(1);
                }
                break;
            case "RocketItem": rocket++;
                break;
            case "ThunderItem": thunder++;
                break;
        }
        return true;
    }

    private void FixedUpdate()
    {
        if (ore >= 10)
        {           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("SavedLevel", SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.PlaySFX("winlevel");
        }
    }
}