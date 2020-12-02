using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    CinemachineVirtualCamera vcamInteractbleObject;
    Button exitInteract;
    AlreadyInteracting alrScript;

    [SerializeField]
    private UnityEvent interactedShowDialogue;
    // Start is called before the first frame update
    void Start()
    {
        vcamInteractbleObject = GetComponentInChildren<CinemachineVirtualCamera>(true);
        exitInteract = GameObject.FindGameObjectWithTag("ExitInteract").GetComponentInChildren<Button>(true);
        alrScript = GetComponentInParent<AlreadyInteracting>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(alrScript.isInteracting == true)
        {
            return;
        }
        vcamInteractbleObject.gameObject.SetActive(true);
        exitInteract.gameObject.SetActive(true);
        Invoke("ShowDialogue", 1.8f);
        //exitInteract.enabled = true;
    }

    private void ShowDialogue()
    {
        interactedShowDialogue.Invoke();
    }


    //public void ExitInteract()
    //{
    //    vcamInteractbleObject.gameObject.SetActive(false);
    //    exitInteract.gameObject.SetActive(false);
    //    //exitInteract.enabled = false;
    //}
}
