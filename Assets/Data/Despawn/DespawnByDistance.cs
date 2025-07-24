using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float despawnX = -4f;
    [SerializeField] protected float despawnY = 0;
    protected override bool CanDespawn()
    {
        Vector3 pos = transform.parent.position;
        return pos.x <= this.despawnX;
    }
}
