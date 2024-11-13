using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : HauMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    public List<Transform> Points { get => points;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (Points.Count > 0) return;
        foreach (Transform point in transform) 
        {
            Points.Add(point);
        }
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, Points.Count);
        return Points[rand];
    }
}
