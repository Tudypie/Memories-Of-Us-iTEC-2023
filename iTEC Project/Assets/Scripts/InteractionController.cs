using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{   
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private LayerMask interactableLayer = new LayerMask();

    public GameObject interactImage;

    public event Action<RaycastHit> OnHitSomething;

    public RaycastHit hitInfo;
    public bool hitSomething;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckForInteractable();
    }

 
    void CheckForInteractable()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

        hitSomething = Physics.Raycast(ray, out hitInfo, rayDistance, interactableLayer);

        if(hitSomething)
        {
            OnHitSomething?.Invoke(hitInfo);  
              
            interactImage.SetActive(true); 
        }
        else
        {
            hitInfo = default(RaycastHit);

            interactImage.SetActive(false); 
        }

        Color rayColor = hitSomething ? Color.green : Color.red;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);
    }
            
}