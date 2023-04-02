using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class Journal : MonoBehaviour
{
    [SerializeField] private bool isReading = false;
    [SerializeField] private GameObject journalUI;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private int currentPage = -1;
    
    [SerializeField] private UnityEvent onStopReading;

    private float iDelay = 0.5f;
    private float startIDelay;

    private void Start()
    {
        startIDelay = iDelay;
    }

    private void Update()
    {   
        
        if(iDelay > 0)
        {
            iDelay -= Time.deltaTime;
            return;
        }

        if (!isReading)
            return;

        journalUI.SetActive(true);                                

        if (!Input.GetMouseButtonDown(0))
            return;
    
        
        iDelay = startIDelay;

        if(currentPage >= pages.Length-1)
        {
            isReading = false;
            onStopReading?.Invoke();

            journalUI.SetActive(false);     

            pages[currentPage].SetActive(false);
            currentPage = -1;

            return;
        }

        NextPage();
    }
    public void StartReading()
    {   
        if(iDelay > 0 || isReading)
            return;

        isReading = true;
        NextPage();
    }

    public void NextPage()
    {   
        if(currentPage >= 0)
            pages[currentPage].SetActive(false);

        currentPage++;
        pages[currentPage].SetActive(true);
    }
}
