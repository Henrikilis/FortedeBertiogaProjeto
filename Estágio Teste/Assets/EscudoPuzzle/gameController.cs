using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float spawnTimer;
    public Transform[] spawnPoints;

    [SerializeField] private bool isRunning = true;

    void Start()
    {
      
    }

    
    void Update()
    {
        if(isRunning)
        StartCoroutine(spawnArrow());
    
    }

    IEnumerator spawnArrow()
    {
        isRunning = false;

        int n = Random.Range(0, spawnPoints.Length);
        
        Instantiate(arrowPrefab, spawnPoints[n].transform.position, arrowPrefab.transform.rotation);
      //  , arrowPrefab.transform.parent = this.gameObject.transform


        yield return new WaitForSeconds(spawnTimer);
        isRunning = true;
    }

}
