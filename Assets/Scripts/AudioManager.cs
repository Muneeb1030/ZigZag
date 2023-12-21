using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceSFX;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] Music;
    [SerializeField] private AudioClip ButtonPress;
    [SerializeField] private AudioClip Notify;
    private void Update()
    {
        if (!_audioSourceMusic.isPlaying)
        {
            PlayMusic();
        }
    }
    public void PlayMusic()
    {
        _audioSourceMusic.volume = 0.25f;
        if (!_audioSourceMusic.isPlaying)
        {
            AudioClip randomClip = Music[Random.Range(0, Music.Length)];
            _audioSourceMusic.clip = randomClip;
            _audioSourceMusic.Play();
        }
    }

    public void PlaySFX()
    {
        _audioSourceSFX.clip = ButtonPress;
        _audioSourceSFX.PlayOneShot(_audioSourceSFX.clip);
    }
    public void PlayNotify()
    {
        _audioSourceSFX.clip = Notify;
        _audioSourceSFX.PlayOneShot(_audioSourceSFX.clip);
    }
}
