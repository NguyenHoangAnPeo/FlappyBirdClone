using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioFlappyBird : AnMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hit;
    [SerializeField] protected AudioClip point;
    [SerializeField] protected AudioClip die;
    [SerializeField] protected AudioClip wing;
    [SerializeField] protected AudioFlappyBird instance;
    [SerializeField] public static AudioFlappyBird Instance { get; private set; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
        this.LoadAudioTrigger();
        this.LoadAudioPoint();
        this.LoadAudioDie();
        this.LoadAudioWing();
    }
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // tránh trùng
            return;
        }
        Instance = this;
    }
    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource = transform.Find("AudioSource").GetComponent<AudioSource>();
        Debug.Log(transform.name + "LoadaudioSource:", gameObject);
    }
    protected virtual void LoadAudioWing()
    {
        if (this.wing != null) return;
        this.wing = Resources.Load<AudioClip>("Audio/wing");
        if (this.wing == null)
            Debug.LogWarning("Không tìm thấy file wing.wav trong Resources/Audio/");
    }
    protected virtual void LoadAudioDie()
    {
        if (this.die != null) return;
        this.die = Resources.Load<AudioClip>("Audio/die");
        if (this.die == null)
            Debug.LogWarning("Không tìm thấy file die.wav trong Resources/Audio/");
    }
    protected virtual void LoadAudioPoint()
    {
        if (this.point != null) return;
        this.point = Resources.Load<AudioClip>("Audio/point");
        if (this.point == null)
            Debug.LogWarning("Không tìm thấy file point.wav trong Resources/Audio/");
    }
    protected virtual void LoadAudioTrigger()
    {
        if (this.hit != null) return;
        this.hit = Resources.Load<AudioClip>("Audio/hit");
        if (this.hit == null)
            Debug.LogWarning("Không tìm thấy file hit.wav trong Resources/Audio/");
    }
    public virtual void PlayAudioWing()
    {
        audioSource.PlayOneShot(wing);
    }
    public virtual void PlayAudioPoint()
    {
        audioSource.PlayOneShot(point);
    }
    public virtual void PlayAudioHit()
    {
        audioSource.PlayOneShot(hit);
    }
    public virtual void PlayAudioDie()
    {
        audioSource.PlayOneShot(die);
    }
}
