using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : AnMonoBehaviour
{
    [SerializeField] protected float flapForce = 5f;
    [SerializeField] protected float maxUpAngle = 20f;
    [SerializeField] protected float maxDownAngle = -90f;
    [SerializeField] protected float rotationSpeed = 5f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected AudioFlappyBird audioFlappyBird;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    void Update(){
        this.Fly();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioBird();
    }
     protected virtual void LoadAudioBird()
    {
        if (this.audioFlappyBird != null) return;
        this.audioFlappyBird = transform.parent.GetComponentInChildren<AudioFlappyBird>();
        Debug.Log(transform.name + "LoadaudioFlappyBird:", gameObject);
    }
   
    protected void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flapForce;
            transform.parent.rotation = Quaternion.Euler(0, 0, maxUpAngle);
            AudioFlappyBird.Instance.PlayAudioWing();
        }
        float angle = Mathf.Lerp(maxUpAngle, maxDownAngle, Mathf.InverseLerp(0f, -5f, rb.velocity.y));
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }
}
