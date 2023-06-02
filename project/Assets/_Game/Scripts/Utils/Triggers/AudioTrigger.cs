using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : MonoBehaviour
{
    // Dependencies
    AudioSource audioSource;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    public void PlayAudio(AudioClip audio)
    {
        if (audio != null)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
    
    
}
