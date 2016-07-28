using UnityEngine;
using UnityEngine.Events;

public abstract class PlayOnEvent : MonoBehaviour
{
    public SoundManager soundManager;
    public AudioClip sound;
    protected abstract UnityEventBase playEvent { get; }

    void Start()
    {
        ((UnityEvent) playEvent).AddListener(Play);
    }

    void Play()
    {
        soundManager.PlaySound(sound);
    }
}