using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDespawn : DespawnByDistance
{
    [SerializeField] protected PipeCtrl pipeCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPipeCtrl();
    }
    protected virtual void LoadPipeCtrl() {
        if (this.pipeCtrl != null) return;
        this.pipeCtrl = GetComponentInParent<PipeCtrl>();
        Debug.Log(transform.name + "LoadpipeCtrl", gameObject);
    }
    protected override void DespawnObject()
    {
        pipeCtrl.PipeSpawner.Despawn(transform.parent);
    }
}
