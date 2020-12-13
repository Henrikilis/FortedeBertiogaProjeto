using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BeginOfSceneDialogue : MonoBehaviour
{
    public GameObject movePlayerCameraButtons;
    public GameObject interactWithObjects;
    public Collider[] colliders;
    public AlreadyInteracting alrScript;
    public GameObject dialogueAfterPuzzle;

    [SerializeField]
    private UnityEvent showDialogueInBeginScene;
    // Start is called before the first frame update
    void Start()
    {
        if(PadrePuzzleEnds.puzzlePadreEnds == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Cena Leo 1"))
        {
            dialogueAfterPuzzle.SetActive(false);
        }
        if (PadrePuzzleEnds.puzzleCannonEnds == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Exterior"))
        {
            dialogueAfterPuzzle.SetActive(false);
        }
        if (PadrePuzzleEnds.puzzleCannonEnds == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Exterior"))
        {
            dialogueAfterPuzzle.SetActive(true);
            this.gameObject.SetActive(false);
            return;
        }
        if (PadrePuzzleEnds.puzzlePadreEnds == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Cena Leo 1"))
        {
            dialogueAfterPuzzle.SetActive(true);
            this.gameObject.SetActive(false);
            return;
        }
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

    public void BeginDialogueEnds()
    {
        alrScript.isInteracting = false;
        foreach (Collider c in colliders)
        {
            c.enabled = true;
        }
        Destroy(this.gameObject, 1f);
    }
}
