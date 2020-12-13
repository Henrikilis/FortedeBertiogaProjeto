using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cutsceneScript : MonoBehaviour
{
    public Animator panelAnim;
    public Image img1;
    public Image img2;
    public Image img3;

   

    [SerializeField]
    private float timer1;
    [SerializeField]
    private float timer2;
    [SerializeField]
    private float timer3;

    public float Speed;
    public float Speed2;
    private bool trans1;
    private bool trans2;
    private bool trans0;
    void Start()
    {
        Invoke(nameof(transition0), 3f);
        Invoke(nameof(transition1), timer1);
        Invoke(nameof(transition2), timer2);
        Invoke(nameof(transition3), timer3);
        trans0 = false;
        trans1 = false;
        trans2 = false;
        
    }

    private void LateUpdate()
    {
        var delta = Vector3.one * Speed * Time.deltaTime;
        var escalaDesejada = img1.transform.localScale + delta;
        var delta2 = Vector3.one * Speed2 * Time.deltaTime;      
        var escalaDesejada2 = img2.transform.localScale + delta2;

         if(trans0)
            img1.transform.localScale = escalaDesejada;

        if (trans1)
            img2.transform.localScale = escalaDesejada2;
    }

    void transition0()
    {
        trans0 = true;
    }

    void transition1()
    {
        trans0 = false;
        trans1 = true;
        img1.gameObject.SetActive(false);
        img2.gameObject.SetActive(true);

    }

    void transition2()
    {
        trans1 = false;
        trans2 = true;
        img2.gameObject.SetActive(false);
        img3.gameObject.SetActive(true);

    }

    void transition3()
    {
        panelAnim.SetBool("start", true);
        trans1 = false;
        trans2 = false;
        img3.gameObject.SetActive(false);

    }

}
