using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    [SerializeField] private InteractionController interactionController;

    [SerializeField] private UnityEvent onDropItem;

    private Interactable interactable;
    private Rigidbody rb;

    private bool isHoldingThisItem = false;
    private bool lerpPos = false;

    public string itemId;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        interactable.enabled = interactionController.isHoldingItem? false : true;

        if(isHoldingThisItem && Input.GetKeyDown(KeyCode.G))
        {
            transform.SetParent(null);

            interactionController.isHoldingItem = false;

            isHoldingThisItem = false;

            rb.isKinematic = false;

            onDropItem?.Invoke();
        }
            

        if(!lerpPos)
            return;

        transform.position = Vector3.Lerp(transform.position, itemHolder.position, 0.05f);

        if(Vector3.Distance(transform.position, itemHolder.position) < 0.1f)
            lerpPos = false;
    }


    public void Interact()
    {
        if(interactionController.isHoldingItem)
            return;

        transform.SetParent(itemHolder);

        rb.isKinematic = true;

        lerpPos = true;
        
        interactionController.isHoldingItem = true;

        isHoldingThisItem = true;
    }
}
