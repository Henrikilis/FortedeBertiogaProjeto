using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class gameController : MonoBehaviour
{
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI TimerText;

    public GameObject StartScreen;
    public GameObject LostScreen;
    public GameObject WonScreen;

    public int MaxLife;
    private int CurrentLife;

    public float TimerTime;
    public bool HasBegun = false;
    public string FortScene;

    public GameObject arrowPrefab;
    public float spawnTimer;
    public Transform[] spawnPoints;
    private bool isRunning = true;
    private bool gameOver = false;
    private bool youWin = false;
    

    void Start()
    {
        CurrentLife = MaxLife;
        LifeText.SetText(MaxLife.ToString());
        TimerText.SetText(TimerTime.ToString());
    }

    
    void Update()
    {
        if (HasBegun) {

            if(isRunning)
            StartCoroutine(spawnArrow());

            TimerTime -= Time.deltaTime;
            TimerText.SetText(TimerTime.ToString("N0"));             
        }

        if (CurrentLife == 0)
        {
            HasBegun = false;
            gameOver = true;

        }

        if (TimerTime == 0)
        {
            HasBegun = false;
            youWin = true;
        }

        if (youWin)
        WonScreen.SetActive(true);

        if (gameOver)
        LostScreen.SetActive(true);


    }

    IEnumerator spawnArrow()
    {
        isRunning = false;

        int n = Random.Range(0, spawnPoints.Length);
        
        Instantiate(arrowPrefab, spawnPoints[n].transform.position, arrowPrefab.transform.rotation);
      //  , arrowPrefab.transform.parent = this.gameObject.transform
       //lalalaala

        yield return new WaitForSeconds(spawnTimer);
        isRunning = true;
    }

    public void TakeDamage(int amount)
    {
        CurrentLife += amount;
        LifeText.SetText(CurrentLife.ToString());

    }

    public void startGame()
    {
        StartScreen.gameObject.SetActive(false);
        HasBegun = true;

    }

    public void restartScene()
    {
        LostScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void goBackToFort()
    {
        SceneManager.LoadScene(FortScene);
    }
}
