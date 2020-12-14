using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConnector : MonoBehaviour
{
    public PieceConnector connector;
    public PadrePiece parentPiece;
    public bool isSnapped;
    [HideInInspector] public bool foundConnection;

    public GameObject ConnectorFX;

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

    private void Update()
    {


        if (ConnectorFX != null)
        {
            if (!isSnapped)
            {
                if (Vector3.Distance(connector.transform.position, this.transform.position) < 1.5f)
                {
                    ConnectorFX.SetActive(true);
                }
                else
                {
                    ConnectorFX.SetActive(false);
                }
            }
            else
            {
                ConnectorFX.SetActive(false);
            }
        }
    }

}
