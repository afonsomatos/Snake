using UnityEngine;

[RequireComponent( typeof(AudioSource) )]
public class MusicManager : Singleton<MusicManager> {

    protected override void Start()
    {
        base.Start();

        if (instance && GameSettings.musicOn)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
