using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOnTrigger : AnMonoBehaviour
{
    [SerializeField] protected AudioFlappyBird audioFlappyBird;

    private bool isInPointZone = false;
    void Update()
    {
        if (isInPointZone)
        {
            GameCtrl.instance.IncreaseScore();
            isInPointZone = false;
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioBird();
    }
    protected virtual void LoadAudioBird()
    {
        if (this.audioFlappyBird != null) return;
        this.audioFlappyBird = transform.GetComponentInChildren<AudioFlappyBird>();
        Debug.Log(transform.name + "LoadaudioFlappyBird:", gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PipeSpawner") || other.CompareTag("Floor"))
        {
            AudioFlappyBird.Instance.PlayAudioHit();
            GameCtrl.instance.GameOver();
            AudioFlappyBird.Instance.PlayAudioDie();
        }

        if (other.CompareTag("PointZone"))
        {
            isInPointZone = true;
            AudioFlappyBird.Instance.PlayAudioPoint();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PointZone"))
        {
            isInPointZone = false;
        }
    }
}
