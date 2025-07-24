using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFly : ParentFly
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
        if (this.pipeCtrl == null)
            Debug.LogWarning(transform.name + " failed to load PipeCtrl", gameObject);
        else
            Debug.Log(transform.name + " loaded PipeCtrl", gameObject);
    }
    protected override void OnEnable()
    {
        this.ResetValue();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        if (pipeCtrl == null || pipeCtrl.PipeSpawner == null) return;

        this.moveSpeed = pipeCtrl.PipeSpawner.Speed();
        this.direction = Vector3.left;
    }
}
