using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : AnMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] protected float time = 20f;
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);//this.direction: la mot vector 3, this.speed: toc do di chuyen, tim.deltatime: di chuyen tgian thuc, k bi han che boi frame;
    }
     protected override void OnEnable()
    {
        //for override;
    }
}
