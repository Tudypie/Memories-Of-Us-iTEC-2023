using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{   
    [SerializeField] private UnityEvent onTriggerEvent;
    [SerializeField] private UnityEvent onEndTriggerEvent;
    [SerializeField] private float delayBetweenEvents = 5f;
    [SerializeField] private bool oneTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            if(oneTime)
                GetComponent<Collider>().enabled = false;
                
            onTriggerEvent?.Invoke();

            Invoke("EndTriggerEvent", delayBetweenEvents);
        }
    }

    private void EndTriggerEvent() => onEndTriggerEvent?.Invoke();
}
