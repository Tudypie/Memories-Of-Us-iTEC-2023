using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactEvent;

    private InteractionController interactionController;

    private bool canInteract = false;

    private void Start()
    {
        if(interactionController == null)
            interactionController = GameObject.FindObjectOfType<InteractionController>();

        interactionController.OnHitSomething += CheckInteraction;
    }

    private void OnDestroy()
    {
        interactionController.OnHitSomething -= CheckInteraction;
    }

    private void Update()
    {   
        if(!canInteract)
            return;

        if(!Input.GetKeyDown(interactKey))
            return;
    
        interactEvent?.Invoke();
    }

    private void CheckInteraction(RaycastHit hit)
    {
        canInteract = hit.collider == GetComponent<Collider>();
    }

}