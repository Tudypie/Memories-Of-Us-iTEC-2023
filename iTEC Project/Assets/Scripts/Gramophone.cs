using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Gramophone : MonoBehaviour
{
    
    [SerializeField] private List <AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private int currentAudioClip = 0;

    private float iDelay = 0.5f;
    private float startIDelay = 0.5f;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        startIDelay = iDelay;
    }

    private void Update()
    {
        if (iDelay > 0)
            iDelay -= Time.deltaTime;
    }

    public void Interact()
    {
        if (iDelay > 0)
            return;

        audio.clip = audioClips[currentAudioClip];
        audio.Play();

        currentAudioClip++;

        iDelay = startIDelay;
    }
}
