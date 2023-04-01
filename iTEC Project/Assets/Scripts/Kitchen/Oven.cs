using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class Oven : MonoBehaviour
{   
    [SerializeField] private InteractionController interactionController;
    [SerializeField] private GameObject tray;
    [SerializeField] private UnityEvent ovenEvent;

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }


    public void Interact()
    {   
        interactionController.isHoldingItem = false;

        anim.Play("InsertTray");

        ovenEvent?.Invoke();
    }
}
