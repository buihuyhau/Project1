using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{
    public GameObject gameOverUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void ResetValue()
    {
        hpMax = 5;
    }
    protected override void OnDead()
    {
        OnDeadFX();
        Invoke("LoadGameOverUI", 0.1f);
        AudioManager.Instance.PlaySFX("over1");
        AudioManager.Instance.PlayMusic("over2");

    }
    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        AudioManager.Instance.PlaySFX("explonsion2");

        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.explosion1;
    }
    protected void LoadGameOverUI()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
