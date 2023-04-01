using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrepareCake : MonoBehaviour
{   
    [SerializeField] private CakeBowl cakeBowl;
    [SerializeField] private GameObject bakedCake;
    [SerializeField] private GameObject burnedCake;
    [SerializeField] private GameObject cakeLayer;
    [SerializeField] private float timer = 20f;

    [SerializeField] private UnityEvent onFinishEvent;

    private bool startedOven = false;

    [SerializeField] private Animation anim;


    private void Update()
    {   
        if(!startedOven)
            return;

        if(startedOven && timer > 0){
            timer -= Time.deltaTime;
            return;
        }

        if(timer <= 0)
        {   
            if(cakeBowl.currentOrder != cakeBowl.correctOrder)
                burnedCake.SetActive(true);
            else
                bakedCake.SetActive(true);

            cakeLayer.SetActive(false);
            
            anim.Play("InsertTray");
            startedOven = false;
            onFinishEvent?.Invoke();
        }


    }

    public void StartOven()
    {   
        startedOven = true;
        anim.Play("CloseOven");
    }

}
