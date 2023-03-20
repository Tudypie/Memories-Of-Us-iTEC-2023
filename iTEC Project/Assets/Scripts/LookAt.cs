using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(mainCamera);
    }
}
