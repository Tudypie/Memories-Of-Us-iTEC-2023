using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDoor : MonoBehaviour
{   
    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim[anim.clip.name].speed = 1f;
            anim.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (anim.isPlaying) {
                anim[anim.clip.name].speed = -1f;
                anim.Play();
            }
            else
            {
                anim[anim.clip.name].speed = -1f;
                anim[anim.clip.name].time = anim[anim.clip.name].length;
                anim.Play();
            }
        }
    }
}
