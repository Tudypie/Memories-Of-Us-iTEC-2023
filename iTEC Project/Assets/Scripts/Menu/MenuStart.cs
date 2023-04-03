using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuStart : MonoBehaviour
{

    [SerializeField] private UnityEvent OnStartGame;

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if(Input.GetMouseButtonDown(0))
           OnStartGame?.Invoke();
    }
}
