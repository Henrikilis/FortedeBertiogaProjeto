using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CannonPuzzleScript : MonoBehaviour
{
    public GameObject shipPrefab;
    public GameObject allyShipPrefab;
    public string sceneToChange;

    [Header("Game Variables")]
    public float objective;
    public float vidas = 3;
    [SerializeField]
    private float objectiveCount;

    public float spawnHeight;
    [Header("Enemy Spawn Timers")]
    public float minTime = 8;
    public float maxTime = 14;
    public float spawnTime = 10;
    [SerializeField]
    private float currentSpawnTime;

    [Header("Ally Spawn Timers")]
    public float aMinTime = 8;
    public float aMaxTime = 14;
    public float aSpawnTime = 10;
    [SerializeField]
    private float aCurrentSpawnTime;

    [Header("tela de termino")]
    public GameObject PreStartScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public bool playing = false;

    [Header("HUD")]
    public TMP_Text inimigosAbatidosTxt;
    public TMP_Text vidasTxt;

    private void Start()
    {
        playing = false;
        PreStartScreen.SetActive(true);
    }
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
        if (playing)
        {
            Spawner();
            AllySpawner();
        }
        AttText();
    }

    #region Funçoes Gerais
    private void Spawner()
    {
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime >= spawnTime)
        {
            Spawn();
            currentSpawnTime = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }
    }

    private void AllySpawner()
    {
        aCurrentSpawnTime += Time.deltaTime;

        if (aCurrentSpawnTime >= aSpawnTime)
        {
            SpawnAlly();
            aCurrentSpawnTime = 0;
            aSpawnTime = Random.Range(aMinTime, aMaxTime);
        }
    }

    private void Spawn()
    {
        float r1 = Random.Range(15, 40);


        float r2 = 50;

        if (Random.value < 0.5f)
        {
            r2 *= -1;
        }

        Vector3 spawnPos = new Vector3(Camera.main.transform.position.x + r2, spawnHeight, r1);
        GameObject obj = Instantiate(shipPrefab);
        Destroy(obj, 60);
        obj.transform.position = spawnPos;
        obj.GetComponent<ShipScript>().manager = this;
        if (r2 > 0)
        {
            obj.GetComponent<ShipScript>().direita = false;
            obj.transform.localScale = new Vector3(obj.transform.localScale.x * -1, obj.transform.localScale.y, obj.transform.localScale.z);
        }
    }

    private void SpawnAlly()
    {
        float r1 = Random.Range(15, 40);


        float r2 = 50;

        if (Random.value < 0.5f)
        {
            r2 *= -1;
        }

        Vector3 spawnPos = new Vector3(Camera.main.transform.position.x + r2, spawnHeight, r1);
        GameObject obj = Instantiate(allyShipPrefab);
        Destroy(obj, 60);
        obj.transform.position = spawnPos;
        obj.GetComponent<ShipScript>().manager = this;
        if (r2 > 0)
        {
            obj.GetComponent<ShipScript>().direita = false;
            obj.transform.localScale = new Vector3(obj.transform.localScale.x * -1, obj.transform.localScale.y, obj.transform.localScale.z);
        }
    }

    public void EnemyHit()
    {
        objectiveCount++;
        if (objectiveCount >= objective)
        {
            Vitoria();
        }

    }

    public void AllyHit()
    {
        vidas--;
        if (vidas <= 0)
        {
            Derrota();
        }
    }
    #endregion

    #region Vitoria/Derrota
    private void Vitoria()
    {
        playing = false;

        PadrePuzzleEnds.puzzleCannonEnds = true;

        winScreen.SetActive(true);

        SceneManager.LoadScene(sceneToChange);
    }

    private void Derrota()
    {
        playing = false;

        loseScreen.SetActive(true);
    }
    #endregion

    #region Start

    public void StartMinigame()
    {
        PreStartScreen.SetActive(false);
        playing = true;
    }

    #endregion

    #region HUD

    private void AttText()
    {
        inimigosAbatidosTxt.text = "Inimigos Afundados: " + objectiveCount.ToString() + "/" + objective.ToString();
        vidasTxt.text = "Vidas: " + vidas.ToString();
    }

    #endregion


    //usava para 2D
    //public void Toque()
    //{
    //    Debug.Log("tapped");
    //    objectiveCount++;
    //    if (objectiveCount >= objective)
    //    {
    //        Debug.Log("Over");
    //    }
    //}

    //public void AllyToque()
    //{
    //    Debug.Log("ally");
    //    objectiveCount--;
    //}

}
