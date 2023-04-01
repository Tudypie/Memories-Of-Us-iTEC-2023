using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    [SerializeField] private InteractionController interactionController;
    private Interactable interactable;

    public string itemId;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        interactable.enabled = interactionController.isHoldingItem? false : true;
    }

    public void Interact()
    {
        if(interactionController.isHoldingItem)
            return;

        transform.SetParent(itemHolder);
        transform.position = itemHolder.position;

        interactionController.isHoldingItem = true;
    }
}
