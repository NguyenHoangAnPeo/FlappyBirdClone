using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCtrl : AnMonoBehaviour
{
    [SerializeField] protected PipeSpawner pipeSpawner;
    [SerializeField] public PipeSpawner PipeSpawner { get => pipeSpawner; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPipeSpawner();
    }
    protected virtual void LoadPipeSpawner()
    {
         if (this.pipeSpawner != null) return;
        this.pipeSpawner = GetComponentInChildren<PipeSpawner>();
        Debug.Log(transform.name + "LoadPipeSpawner", gameObject);
    }
}
