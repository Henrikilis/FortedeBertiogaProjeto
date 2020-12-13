using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BeginOfSceneDialogueAfterPuzzles : MonoBehaviour
{
    public GameObject movePlayerCameraButtons;
    public GameObject interactWithObjects;
    public Collider[] colliders;
    public AlreadyInteracting alrScript;

    public string sceneEndGame;

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

    public void BeginDialogueEnds()
    {
        alrScript.isInteracting = false;
        //movePlayerCameraButtons.SetActive(true);
        SceneManager.LoadScene(sceneEndGame);
        //Destroy(this.gameObject, 1f);
    }

    public void EndGame()
    {
        alrScript.isInteracting = false;
        SceneManager.LoadScene(sceneEndGame);
    }
}

