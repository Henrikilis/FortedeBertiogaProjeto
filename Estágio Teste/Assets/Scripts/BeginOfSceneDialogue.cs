using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeginOfSceneDialogue : MonoBehaviour
{
    public GameObject movePlayerCameraButtons;
    public GameObject interactWithObjects;
    public Collider[] colliders;
    public AlreadyInteracting alrScript;

    [SerializeField]
    private UnityEvent showDialogueInBeginScene;
    // Start is called before the first frame update
    void Start()
    {
        alrScript.isInteracting = true;
        showDialogueInBeginScene.Invoke();
        movePlayerCameraButtons.SetActive(false);
        colliders = interactWithObjects.GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateObjects()
    {
        movePlayerCameraButtons.SetActive(true);
        alrScript.isInteracting = false;
        foreach (Collider c in colliders)
        {
            c.enabled = true;
        }

        Destroy(this.gameObject, 1f);
    }
}
