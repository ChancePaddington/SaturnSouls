using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] public AudioSource soundFXObject;
    [SerializeField] public AudioSource soundLoopFXObject;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign the audioClip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //Play sound
        float clipLength = audioSource.clip.length;
        audioSource.Play();

        //Destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    //Another function which plays a looping clip
    public AudioSource PlayLoopFXSound(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundLoopFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //Play sound
        float clipLength = audioSource.clip.length;
        audioSource.Play();

        return audioSource;
    }

}
