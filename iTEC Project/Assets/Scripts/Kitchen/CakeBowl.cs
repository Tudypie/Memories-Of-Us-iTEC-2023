using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class CakeBowl : MonoBehaviour
{
    [SerializeField] private InteractionController interactionController;
        
    [SerializeField] private GameObject itemHolder;

    [SerializeField] private GameObject[] layers;
    private int currentLayer = 0;

    public string correctOrder = "1234";
    public string currentOrder = "";

    [SerializeField] private UnityEvent onFinishEvent;

    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }


    private void Update()
    {
        interactable.enabled = interactionController.isHoldingItem? true : false;
    }

    public void Interact()
    {   
        if(currentLayer >= layers.Length-1)
        {
            onFinishEvent?.Invoke();
        }
            
        interactionController.isHoldingItem = false;

        currentOrder += itemHolder.transform.GetChild(0).gameObject.
                            GetComponent<ItemPickup>().itemId;

        Destroy(itemHolder.transform.GetChild(0).gameObject);

        layers[currentLayer].SetActive(true);

        currentLayer++;
    }

}
