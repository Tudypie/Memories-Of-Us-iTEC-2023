using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTray : MonoBehaviour
{
    [SerializeField] private GameObject bakedCake;
    [SerializeField] private GameObject burnedCake;
    [SerializeField] private CakeBowl cakeBowl;

    private void Update()
    {
        if(cakeBowl.currentOrder != cakeBowl.correctOrder)
            burnedCake.SetActive(true);
        else
            bakedCake.SetActive(true);
    }
}
