using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    [SerializeField] private GameObject[] pills;
    int currentPill = 0;

    public void TakePill()
    {   
        if (currentPill >= pills.Length-1)
            return;

        pills[currentPill].SetActive(false);
        currentPill++;
    }
}
