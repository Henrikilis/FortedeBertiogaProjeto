using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject mainMenuOptionsPanel;

    [SerializeField]
    private string beginGameScene;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        mainMenuOptionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(beginGameScene);
        //mainMenuPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
    }

    public void OptionsMenu()
    {
        mainMenuPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(true);
    }

    public void BackButton()
    {
        mainMenuPanel.SetActive(true);
        mainMenuOptionsPanel.SetActive(false);
    }
}
