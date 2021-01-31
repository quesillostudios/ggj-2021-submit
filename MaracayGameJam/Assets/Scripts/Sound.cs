﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
	public string TrackName;
	public AudioClip Clip;

	public AudioMixerGroup MixerGroup;

	[Range(0f, 1f)]
	public float Volume;

	[Range(.1f, 3f)]
	public float Pitch;

	public bool Loop;

	[HideInInspector]
	public AudioSource Source;

    private SoundEffect fx = new SoundEffect();

    public async void FadeIn(float speed)
    {
        Source.volume = 0;
        Source.Play();

        bool fxStatus = await fx.MaxTrackIn(this, speed);

        Debug.Log($"El efecto ha terminado en: {fxStatus}");
    }

    public async void FadeOut(float speed)
    {
        bool fxStatus = await fx.MaxTrackOut(this, speed);

        Debug.Log($"El efecto ha terminado en: {fxStatus}");

        Source.Stop();
    }

	// public IEnumerator FadeIn(float speed)
    // {   
    //     Source.volume = 0;
    //     Source.Play();
        
    //     while (Source.volume < 1)
    //     {
    //         Source.volume += speed;
    //         yield return new WaitForSeconds(0.1f);
    //     }

    //     yield break;
    // }

    // public IEnumerator FadeOut(float speed)
    // {
    //     while (Source.volume > 0)
    //     {
    //         Source.volume -= speed;
    //         yield return new WaitForSeconds(0.1f);
    //     }

    //     Source.Stop();

    //     yield break;
    // }
}
