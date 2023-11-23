using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterOnOff : MonoBehaviour
{
    public GameObject lighter;
    public GameObject flames;
    public AudioSource lighterAudio; // Add an AudioSource component to the same GameObject
    public AudioClip igniteSound; // Assign the clicking sound clip in the Inspector

    private bool isOn;

    void Start()
    {
        isOn = false;
        flames.SetActive(false);
        lighterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && lighter.activeInHierarchy && !isOn)
        {
            flames.SetActive(true);
            isOn = true;

            // Play the ignition sound
            PlayIgniteSound();
        }
        else if (Input.GetButtonDown("Fire1") && isOn)
        {
            return;
        }

        if (Input.GetButtonDown("Fire2") && lighter.activeInHierarchy && isOn)
        {
            flames.SetActive(false);
            isOn = false;

            // Play the extinguish sound
            PlayIgniteSound();
        }
    }

    void PlayIgniteSound()
    {
        // Check if AudioSource and AudioClip are assigned
        if (lighterAudio != null && igniteSound != null)
        {
            lighterAudio.clip = igniteSound;
            lighterAudio.Play();
        }
    }
}
