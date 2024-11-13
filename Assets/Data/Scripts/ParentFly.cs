using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HauMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    private void FixedUpdate()
    {
        transform.parent.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }
}
