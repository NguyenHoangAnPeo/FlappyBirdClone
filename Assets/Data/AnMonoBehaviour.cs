using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        Debug.Log("Ham reset da dc chay");
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        //For override;
    }
    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {
        //For  override;
    }
    protected virtual void OnEnable()
    {
        //For override;
    }
}
