using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slideshow : MonoBehaviour
{   
    [SerializeField] private bool clickToContinue;
    [SerializeField] private GameObject[] images;
    [SerializeField] private int currentImage;

    [SerializeField] private UnityEvent OnEndSlideshow;

    private float iDelay = 0.5f;
    private float startIDelay;

    private void Start()
    {
        startIDelay = iDelay;
    }

    private void Update()
    {
        if (iDelay > 0){
            iDelay -= Time.deltaTime;
            return;
        }
        
        if (!Input.GetMouseButtonDown(0))
            return;

        iDelay = startIDelay;
        
        images[currentImage].SetActive(false);
        currentImage++;

        if(currentImage >= images.Length){
            OnEndSlideshow?.Invoke();
            return;
        }

        images[currentImage].SetActive(true);

    }

}
