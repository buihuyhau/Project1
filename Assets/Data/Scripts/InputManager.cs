using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance;}
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos;}
    public float OnFiringBullet { get => onFiringBullet;}

    [SerializeField] protected float onFiringBullet;

    [SerializeField] protected bool onFiringRocket;
    public bool OnFiringRocket  => onFiringRocket;
    [SerializeField] protected bool onFiringThunder;
    public bool OnFiringThunder  => onFiringThunder;


    private void Awake()
    {
        InputManager.instance = this;
    }
    private void Update()
    {
        GetMouseDow();
        GetKeyDow();
    }
    protected void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMouseDow()
    {
        onFiringBullet = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetKeyDow()
    {
        onFiringRocket = Input.GetKey(KeyCode.Return);
        onFiringThunder = Input.GetKey(KeyCode.RightShift);
    }
}
