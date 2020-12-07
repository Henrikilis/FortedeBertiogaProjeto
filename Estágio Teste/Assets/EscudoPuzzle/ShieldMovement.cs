using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShieldMovement : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler  
{
    public Canvas canvas;

    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("drag");
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("OnTheBeningingDrag");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
      //  Debug.Log("OnEndDrag");

    }


    public void OnPointerDown(PointerEventData eventData)
    {
     //   Debug.Log("dale");
       // throw new System.NotImplementedException();
    }

   /* private void OnMouseDrag()
    {

        transform.position = new Vector3(transform.position.x,Input.mousePosition.y, transform.position.z);
    }
    */
}
