using UnityEngine;

[RequireComponent( typeof(AudioSource) )]
public class SoundManager : Singleton<SoundManager> {

    public void PlaySound(AudioClip clip)
    {
        if (instance && GameSettings.soundOn)
        {
            instance.GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
