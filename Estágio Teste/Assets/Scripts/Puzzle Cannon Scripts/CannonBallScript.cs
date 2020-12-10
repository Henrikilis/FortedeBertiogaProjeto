using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    public CannonPuzzleScript ct;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("EnemyShip"))
        {
            ct.EnemyHit();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("AllyShip"))
        {
            ct.AllyHit();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }



}
