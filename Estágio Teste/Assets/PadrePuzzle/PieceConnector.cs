using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConnector : MonoBehaviour
{
    public PieceConnector connector;
    public PadrePiece parentPiece;
    public bool isSnapped;
    [HideInInspector] public bool foundConnection;

    private void Start()
    {
        parentPiece = transform.parent.GetComponent<PadrePiece>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == connector.gameObject)
        {
            foundConnection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == connector.gameObject)
        {
            foundConnection = false;
        }
    }
}
