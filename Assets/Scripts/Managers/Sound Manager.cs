using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public SoundLoopManager loopManager;
    [SerializeField] public AudioSource soundFXObject;
    [SerializeField] public AudioSource soundLoopFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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

    //In a new script (let's call this Loop Sound Activator)
    //This new script would run SoundManager.PlayLoopFXSound()
    //This script will need to store the instantiated audiosource as a variable
    //In the minion script, when the minion is destroyed, it should also talk to the Loop Sound Activator
    //And tell it to destroy the audiosource (which is has stored as a variable)

    //The Loop Sound Activator should be added to the minion prefab

}
