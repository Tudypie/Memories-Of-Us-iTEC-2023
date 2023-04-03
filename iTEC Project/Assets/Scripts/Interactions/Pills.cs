using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    [SerializeField] private GameObject[] pills;
    int currentPill = 0;

    private float iDelay = 0.5f;
    private float startIDelay;

    private void Start()
    {
        startIDelay = iDelay;
    }

    private void Update()
    {
        if (iDelay > 0)
            iDelay -= Time.deltaTime;

    }

    public void TakePill()
    {   
        if(iDelay > 0)
            return;

        pills[currentPill].SetActive(false);
        currentPill++;

        iDelay = startIDelay;
    }
}
