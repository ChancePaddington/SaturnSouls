using UnityEngine;
using UnityEngine.Events;

public class Music : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] AudioClip music;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    public UnityEvent setMusic;


    //public void PlayMusic()
    //{
    //    if (audioSource.isPlaying) return;
    //    audioSource.Play();
    //}

    //public void StopMusic()
    //{
    //    audioSource.Stop();
    //}

}
