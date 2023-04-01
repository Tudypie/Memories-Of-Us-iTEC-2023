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

        currentImage++;

        if(currentImage >= images.Length){
            for(int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(false);
            }

            OnEndSlideshow?.Invoke();
            return;
        }

        images[currentImage].SetActive(true);

    }

}
