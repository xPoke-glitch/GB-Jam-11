using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("References")]
    [SerializeField] List<AudioSource> _audioSources;

    private AudioSource _bgMusicSource = null;

    public void PlayGameBackgroundMusic(AudioClip audioClipToPlay, bool isLooped = false)
    {
        if(_bgMusicSource == null)
            _bgMusicSource = FindFirstEmpty();

        if (!_bgMusicSource)
            return;

        _bgMusicSource.clip = audioClipToPlay;
        _bgMusicSource.loop = isLooped;
        _bgMusicSource.Play();
    }

    public void StopGameBackgroundMusic()
    {
        _bgMusicSource.clip = null;
        _bgMusicSource.loop = false;
        _bgMusicSource.Stop();
    }

    public void PlayAudioEffect(AudioClip audioClipToPlay)
    {
        var audioSource = FindFirstEmpty();
        if (!audioSource)
            return;

        audioSource.PlayOneShot(audioClipToPlay);
    }

    public void SetAudioMuted(bool isMuted)
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.mute = isMuted;
        }

        if (_bgMusicSource)
            _bgMusicSource.mute = isMuted;
    }

    private AudioSource FindFirstEmpty()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }

        return null;
    }
}
