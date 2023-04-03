using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    [SerializeField] private GameObject[] pills;
    int currentPill = 0;

    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if(currentPill >= pills.Length-1)
        {
            interactable.enabled = false;
        }
    }

    public void TakePill()
    {   
        pills[currentPill].SetActive(false);
        currentPill++;
    }
}
