using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Door : MonoBehaviour
{
    bool isOpen = false;

    Animation anim;

    float iDelay = 1.2f;
    float startIDelay;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;


    private void Start()
    {
        anim = GetComponent<Animation>();

        startIDelay = iDelay;
    }

    private void Update()
    {
        if (iDelay > 0)
            iDelay -= Time.deltaTime;
    }

    public void Interact()
    {   
        if(iDelay > 0)
            return;
            
        if (isOpen)
        {
            anim[anim.clip.name].speed = -1f;
            anim[anim.clip.name].time = anim[anim.clip.name].length;
            anim.Play();
            
            audioPlayer.PlayOneShot(openClip);
        }
        else
        {
            anim[anim.clip.name].speed = 1f;
            anim[anim.clip.name].time = 0;
            anim.Play();

            audioPlayer.PlayOneShot(closeClip);
        }

        iDelay = startIDelay;
        isOpen = !isOpen;
    }

}
