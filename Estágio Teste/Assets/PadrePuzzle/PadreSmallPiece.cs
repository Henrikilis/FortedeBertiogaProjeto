using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PadreSmallPiece : MonoBehaviour
{
    Renderer rend;
    PadrePiece parentPiece;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        parentPiece = transform.parent.GetComponent<PadrePiece>();
    }

    /*private void OnMouseEnter()
    {
        rend.material.SetFloat("_Metallic", 0.5f);
    }

    private void OnMouseExit()
    {
        rend.material.SetFloat("_Metallic", 0f);
    }*/

    private void OnMouseDown()
    {
        parentPiece.TouchingDown();
    }

    private void OnMouseUp()
    {
        parentPiece.TouchingUp();
    }
}