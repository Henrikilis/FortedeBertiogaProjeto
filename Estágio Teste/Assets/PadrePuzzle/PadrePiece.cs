using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PadrePiece : MonoBehaviour
{
    [HideInInspector] public PuzzlePadreController controller;
    public List<PadrePiece> snapGroup;
    public List<PieceConnector> connectors;

    [HideInInspector] public Vector3 originalPos;

    Vector3 distDifference;
    bool clicked;

    private void Start()
    {
        connectors.AddRange(GetComponentsInChildren<PieceConnector>());
        foreach (var item in connectors)
        {
            if (!controller.connectors.Contains(item))
                controller.connectors.Add(item);
        }

        snapGroup.Add(this);
    }

    private void Update()
    {
        if (clicked)
        {
            Vector3 point = new Vector3();
            Vector2 mousePos = new Vector2();

            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;

            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

            Vector3 pos = point + distDifference;

            GetComponent<Transform>().position = pos;

            foreach (var item in snapGroup)
            {
                Vector3 pos2 = GetComponent<Transform>().localPosition + (item.originalPos - originalPos);
                item.GetComponent<Transform>().localPosition = pos2;
            }
        }
    }

    public void TouchingDown()
    {
        foreach (var item in snapGroup)
        {
            foreach (var item2 in item.connectors)
            {
                if (!connectors.Contains(item2))
                    connectors.Add(item2);
            }
        }

        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        distDifference = GetComponent<Transform>().position - point;

        clicked = true;
        foreach (var item in connectors)
        {
            item.GetComponent<BoxCollider>().isTrigger = false;
        }




    }

    public void TouchingUp()
    {
        clicked = false;

        foreach (var item in connectors)
        {
            item.GetComponent<BoxCollider>().isTrigger = true;

            if (item.foundConnection)
            {
                item.isSnapped = true;
                item.connector.isSnapped = true;
                item.gameObject.SetActive(false);
                item.connector.gameObject.SetActive(false);
            }

            if (item.foundConnection)
                ConnectorSnap(item);
        }
    }

    void ConnectorSnap(PieceConnector pieceConnector)
    {
        foreach (var item in pieceConnector.connector.parentPiece.snapGroup)
        {
            if (!snapGroup.Contains(item))
                snapGroup.Add(item);
        }
        foreach (var item in snapGroup)
        {
            foreach (var item2 in snapGroup)
            {
                if (!item.snapGroup.Contains(item2))
                    item.snapGroup.Add(item2);
            }

            Vector3 pos = GetComponent<Transform>().localPosition + (item.originalPos - originalPos);
            item.GetComponent<Transform>().localPosition = pos;
        }
    }
}
