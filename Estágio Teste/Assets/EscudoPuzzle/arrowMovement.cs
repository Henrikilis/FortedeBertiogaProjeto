using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowMovement : MonoBehaviour
{
    private Canvas ui;
    public float ArrowSpeed;
    private Transform originalPostion;
    private Rigidbody2D rb;

    void Start()
    {
        ui = FindObjectOfType<Canvas>();
        this.transform.SetParent(ui.transform);
        rb = GetComponent<Rigidbody2D>();
    }


    
    void Update()
    {     
        rb.velocity = new Vector2(rb.velocity.x + ArrowSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "dano")
        {


        }

        Destroy(this.gameObject);

    }

}
