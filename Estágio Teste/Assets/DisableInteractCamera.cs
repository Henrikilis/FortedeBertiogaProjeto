using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInteractCamera : MonoBehaviour
{
    GameObject cameraInteract;
    InteractableObject intOBJ;
    AlreadyInteracting alrScript;
    // Start is called before the first frame update
    void Start()
    {
        //cameraInteract = GameObject.FindGameObjectWithTag("CameraInteract");
        alrScript = GameObject.FindGameObjectWithTag("IsInteracting").GetComponent<AlreadyInteracting>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraInteract = GameObject.FindGameObjectWithTag("CameraInteract");
    }

    public void ButtonExitInteract()
    {
        cameraInteract.SetActive(false);
        this.gameObject.SetActive(false);
        alrScript.isInteracting = false;
    }
}
