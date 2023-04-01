using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuStart : MonoBehaviour
{

    [SerializeField] private UnityEvent OnStartGame;

    void Update()
    {
        if(!Input.anyKey)
            return;

        OnStartGame?.Invoke();
    }
}
