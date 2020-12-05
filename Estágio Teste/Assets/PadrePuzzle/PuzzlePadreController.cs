using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePadreController : MonoBehaviour
{
    public PadrePiece[] pieces;
    public RectTransform[] startingPos;
    [HideInInspector] public List<PieceConnector> connectors;

    public GameObject victoryScreen;

    private void Awake()
    {
        foreach (var item in pieces)
        {
            item.controller = this;
            item.originalPos = item.GetComponent<RectTransform>().localPosition;
        }
        RandomizePiecePos();
    }
    private void Update()
    {
        VictoryCheck();
    }

    void VictoryCheck()
    {
        bool victory = true;
        foreach (var item in connectors)
        {
            if (!item.isSnapped) victory = false;
        }
        if (victory) StartCoroutine(Victory());
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(1.5f);
        victoryScreen.SetActive(true);
    }

    void RandomizePiecePos()
    {
        int[] xxx = { 0, 1, 2, 3, 4, 5, 6, 7 };

        for (int t = 0; t < xxx.Length; t++)
        {
            int tmp = xxx[t];
            int r = Random.Range(t, xxx.Length);
            xxx[t] = xxx[r];
            xxx[r] = tmp;
        }

        for (int i = 0; i < startingPos.Length; i++)
        {
            pieces[xxx[i]].GetComponent<RectTransform>().position = startingPos[i].position;
        }
    }
}
