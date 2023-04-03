using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    [SerializeField] private InteractionController interactionController;
    private Interactable interactable;

    private bool lerpPos = false;

    public string itemId;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        interactable.enabled = interactionController.isHoldingItem? false : true;

        if(!lerpPos)
            return;

        transform.position = Vector3.Lerp(transform.position, itemHolder.position, 0.05f);

        Invoke("StopLerping", 1f);
    }

    public void StopLerping()
    {
        lerpPos = false;
    }

    public void Interact()
    {
        if(interactionController.isHoldingItem)
            return;

        transform.SetParent(itemHolder);
        lerpPos = true;
        
        interactionController.isHoldingItem = true;
    }
}
