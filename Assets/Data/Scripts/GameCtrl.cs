using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : HauMonoBehaviour
{
    private static GameCtrl instance;
    [SerializeField] protected Camera mainCam;
    public static GameCtrl Instance { get => instance;}
    public Camera MainCam { get => mainCam;}

    protected override void Awake()
    {
        base.Awake();
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCam();
    }
    protected virtual void LoadCam()
    {
        if (mainCam != null) { return; }
        mainCam = Transform.FindObjectOfType<Camera>();
    }

}
