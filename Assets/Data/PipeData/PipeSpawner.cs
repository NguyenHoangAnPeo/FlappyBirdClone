using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : Spawner
{
    public static string pipeGreen = "PipeGreen";
    [SerializeField] protected float time = 0f;
    [SerializeField] protected float delayTime = 5f;
    [SerializeField] protected float x = 10f;
    [SerializeField] protected float minY = -2f;
    [SerializeField] protected float maxY = 2f;
    [SerializeField] protected int pipeCount = 0;
    [SerializeField] protected int pipeLimit = 5;
    [SerializeField] protected float pipeSpeed = 3f;
    [SerializeField] protected static PipeSpawner instance;
    [SerializeField] public static PipeSpawner Instance{ get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (PipeSpawner.instance != null) Debug.Log("Only 1 PipeSpawner is exit");
        PipeSpawner.instance = this;
    }
    protected override void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= delayTime)
        {
            this.JunkSpawning();
            pipeCount++;
            time = 0f;
        }
    }
    public virtual float Speed()
    {
        if (pipeCount == pipeLimit)
        {
            pipeSpeed++;
            pipeCount = 0;
        }
        return pipeSpeed;
    }
    protected virtual void JunkSpawning()
    {
        Vector3 ranPos = new Vector3(x, Random.Range(minY, maxY), 0f);
        Quaternion rot = transform.rotation;
        Transform obj = this.Spawn(pipeGreen, ranPos, rot);
        obj.gameObject.SetActive(true);
    }
}
