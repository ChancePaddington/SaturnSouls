using UnityEngine;
using UnityEngine.Rendering;

public class SoundLoopManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public SoundManager soundManager;

    public void PlayLoopFXSound(AudioClip audioClip, Transform spawnTransform, float volume)
    {
       AudioSource audioSource = Instantiate(soundManager.soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        float clipLength = audioSource.clip.length;
        audioSource.Play();

        //Destroy(audioSource.gameObject, clipLength);
    }
}
