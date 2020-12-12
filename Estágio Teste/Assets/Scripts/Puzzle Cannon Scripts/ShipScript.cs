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

    public bool dead;
    bool once;
    public GameObject modelAlive;
    public GameObject modelDead;

    //void OnEnable()
    //{
    //    GetComponent<TapGesture>().Tapped += Toque;
    //}

    //void OnDisable()
    //{
    //    GetComponent<TapGesture>().Tapped -= Toque;
    //}

    private void Update()
    {
        if (dead && !once)
        {
            once = true;

            modelAlive.SetActive(false);
            modelDead.SetActive(true);
            Destroy(gameObject, 10);
        }
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            MoveShip();
        }
        else
        {
            MoveShipDead();
        }
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

    void MoveShipDead()
    {
        Vector3 pos = transform.position;

        if (direita)
        {
            pos.x += speed/3 * Time.deltaTime;
        }

        else
        {
            pos.x -= speed/3 * Time.deltaTime;
        }

        pos.y -= speed / 3 * Time.deltaTime;

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
