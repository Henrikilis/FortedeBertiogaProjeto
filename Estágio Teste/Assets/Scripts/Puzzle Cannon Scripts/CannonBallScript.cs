using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    public CannonPuzzleScript ct;

    Rigidbody rb;
    SphereCollider col;
    MeshRenderer rend;

    public GameObject FX_Splash;
    public GameObject FX_Impact;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        rend = GetComponent<MeshRenderer>();
    }

    void DeactivateBall()
    {
        col.enabled = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rend.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Agua"))
        {
            DeactivateBall();
            FX_Splash.SetActive(true);
            Destroy(gameObject, 5);
        }
        if (collision.transform.CompareTag("EnemyShip"))
        {
            ct.EnemyHit();
            collision.gameObject.GetComponent<ShipScript>().dead = true;
            FX_Impact.SetActive(true);
            DeactivateBall();
            Destroy(gameObject, 5);
        }
        if (collision.transform.CompareTag("AllyShip"))
        {
            ct.AllyHit();
            collision.gameObject.GetComponent<ShipScript>().dead = true;
            FX_Impact.SetActive(true);
            DeactivateBall();
            Destroy(gameObject, 5);
        }
    }



}
