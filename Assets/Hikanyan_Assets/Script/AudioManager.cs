using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AbstractSingleton<AudioManager>
{
    private AudioSource bgmAudioSource;
    public void PlaySoundEffect(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = clip;

        audioSource.Play();

        Destroy(audioSource, clip.length);
    }

    public void PlayMusic(AudioClip clip)
    {
        StopMusic();

        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        bgmAudioSource.clip = clip;

        bgmAudioSource.loop = true;

        bgmAudioSource.Play();
    }

    public void StopMusic()
    {
        if (bgmAudioSource != null && bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Stop();
            Destroy(bgmAudioSource);
        }
    }
}
