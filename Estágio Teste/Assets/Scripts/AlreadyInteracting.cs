using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlreadyInteracting : MonoBehaviour
{
    GameObject cameraInteract;
    public bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
        //cameraInteract = GameObject.FindGameObjectWithTag("CameraInteract");
    }

    // Update is called once per frame
    void Update()
    {
        cameraInteract = GameObject.FindGameObjectWithTag("CameraInteract");

        if(cameraInteract != null)
        {
            if(cameraInteract.gameObject.activeSelf == true)
            {
                isInteracting = true;
            }
        }
    }
}
