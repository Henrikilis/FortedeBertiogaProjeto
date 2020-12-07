using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadPuzzlesScenes : MonoBehaviour
{
    [SerializeField]
    private string puzzleScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPuzzleScene()
    {
        SceneManager.LoadScene(puzzleScene);
    }
}
