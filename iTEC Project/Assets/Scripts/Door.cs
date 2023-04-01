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
        }
        else
        {
            anim[anim.clip.name].speed = 1f;
            anim[anim.clip.name].time = 0;
            anim.Play();
        }

        iDelay = startIDelay;
        isOpen = !isOpen;
    }

}
