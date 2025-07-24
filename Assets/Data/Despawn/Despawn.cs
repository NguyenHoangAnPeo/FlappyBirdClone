using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : AnMonoBehaviour
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
        Debug.Log("Destroy Object");
    }
    protected abstract bool CanDespawn();
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
