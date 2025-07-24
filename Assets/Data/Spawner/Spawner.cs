using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : AnMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;
    protected override void LoadComponent()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name+"LoadHolder:", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        //For override
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefab");
        if (prefabObj == null)
        {
            Debug.Log("Khong tim thay doi tuong prefab trong " + gameObject.name);
            return;
        }
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab != null)
            {
                prefab.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Mot prefab trong danh sach bi null");
            }
        }
    }
    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);        
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Khong the lay prefab nay: " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.SetParent(this.holder,true);
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }

        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
}
