using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class ShipScript : MonoBehaviour
{
    //public bool ally;

    public bool direita;

    public float speed = 20;

    public CannonPuzzleScript manager;

    //void OnEnable()
    //{
    //    GetComponent<TapGesture>().Tapped += Toque;
    //}

    //void OnDisable()
    //{
    //    GetComponent<TapGesture>().Tapped -= Toque;
    //}

    private void FixedUpdate()
    {
        MoveShip();
    }

    void MoveShip ()
    {
        Vector3 pos = transform.position;

        if (direita)
        {
            pos.x += speed * Time.deltaTime;
        }

        else
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;

    }

    //void Toque(object o, EventArgs e)
    //{
    //    if (ally)
    //    {
    //        manager.AllyToque();
    //    }
    //    else
    //    {
    //        manager.Toque();
    //    }
    //    Destroy(gameObject);
    //}

}
