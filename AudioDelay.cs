using System.Collections;
using UnityEngine;

public class AudioDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip yourAudioClip;
    
    public float delay = 5f;

    void Start()
    {
        // Set the audio clip to play on the AudioSource
        audioSource.clip = yourAudioClip;

        // Start the coroutine to play the audio with a delay
        StartCoroutine(PlayAudioWithDelay());
    }

    IEnumerator PlayAudioWithDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(delay);

        // Play the audio clip on the AudioSource
        audioSource.Play();
    }
}
