using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    const string MUSIC_EXPOSED_VARIABLE = "Music";
    const string SOUNDFX_EXPOSED_VARIABLE = "SFX";
    AudioMixer audioMixer;

    void Start()
    {
        audioMixer = SoundHandler.Instance.AudioMixer;

        // bool isMusicOn = PlayerPrefs.GetInt(MUSIC_EXPOSED_VARIABLE, 1) > 0;
        // bool isSoundFXOn = PlayerPrefs.GetInt(SOUNDFX_EXPOSED_VARIABLE, 1) > 0;

        // if (isMusicOn)
        // {
        //     audioMixer.SetFloat(MUSIC_EXPOSED_VARIABLE, 0);
        // }
        // else
        // {
        //     audioMixer.SetFloat(MUSIC_EXPOSED_VARIABLE, -80);
        // }

        // if (isSoundFXOn)
        // {
        //     audioMixer.SetFloat(SOUNDFX_EXPOSED_VARIABLE, 0);
        // }
        // else
        // {
        //     audioMixer.SetFloat(SOUNDFX_EXPOSED_VARIABLE, -80);
        // }
    }
}
