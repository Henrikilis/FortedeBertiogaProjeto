using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePadreController : MonoBehaviour
{
    public PadrePiece[] pieces;
    public Transform[] startingPos;
    [HideInInspector] public List<PieceConnector> connectors;

    public GameObject victoryScreen;

    public string changeScene;

    private void Awake()
    {
        PadrePuzzleEnds.puzzlePadreEnds = false;
        foreach (var item in pieces)
        {
            item.controller = this;
            item.originalPos = item.GetComponent<Transform>().localPosition;
        }
        RandomizePiecePos();
    }
    private void Update()
    {
        Debug.Log("sdfsf: " + PadrePuzzleEnds.puzzlePadreEnds);
        VictoryCheck();
    }

    void VictoryCheck()
    {
        bool victory = true;
        foreach (var item in connectors)
        {
            if (!item.isSnapped) victory = false;
        }
        //if (victory) StartCoroutine(Victory());
        if (victory)
        {
            StartCoroutine(Victory());
            SceneManager.LoadScene(changeScene);
            PadrePuzzleEnds.puzzlePadreEnds = true;
        }
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(1.5f);
        victoryScreen.SetActive(true);
    }

    void RandomizePiecePos()
    {
        int[] xxx = { 0, 1, 2, 3, 4, 5 };

        for (int t = 0; t < xxx.Length; t++)
        {
            int tmp = xxx[t];
            int r = Random.Range(t, xxx.Length);
            xxx[t] = xxx[r];
            xxx[r] = tmp;
        }

        for (int i = 0; i < startingPos.Length; i++)
        {
            pieces[xxx[i]].GetComponent<Transform>().position = startingPos[i].position;
        }
    }
}
