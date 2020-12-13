using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorLock : MonoBehaviour
{
    public GameObject doorLocked;
    public GameObject doorUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PadrePuzzleEnds.puzzlePadreEnds == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Cena Leo 1"))
        {
            doorLocked.SetActive(false);
            doorUnlocked.SetActive(true);
        }
    }
}
