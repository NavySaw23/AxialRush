using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip firstClip;
    public AudioClip secondClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = firstClip;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = secondClip;
            audioSource.Play();
        }
    }
}
