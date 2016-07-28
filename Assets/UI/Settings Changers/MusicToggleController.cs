using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent( typeof(Toggle) )]
public class MusicToggleController : MonoBehaviour {

    private Toggle toggle;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = MusicManager.instance.GetComponent<AudioSource>();

        toggle = GetComponent<Toggle>();
        toggle.isOn = GameSettings.musicOn;
        ToggleMusic(GameSettings.musicOn);
        toggle.onValueChanged.AddListener(ToggleMusic);
    }

    void ToggleMusic(bool isOn)
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

        GameSettings.musicOn = isOn;
        if (isOn) audioSource.UnPause(); 
        else audioSource.Pause();
    }
}
