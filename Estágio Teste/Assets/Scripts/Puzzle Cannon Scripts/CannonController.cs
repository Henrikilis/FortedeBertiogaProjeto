using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CannonController : MonoBehaviour
{

    public float speed;
    public float friction;
    public float lerpSpeed;
    float direction;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;

    [SerializeField]
    private float rotateYTimer;

    [Header("Firing Variables")]
    public GameObject cannonBall;
    Rigidbody cannonballRB;
    public Transform shotPos;

    public float firePower;
    public float fireCooldown = 2;
    private float fireCooling;

    public CannonPuzzleScript ct;
    public GameObject explosionEffect;
    public GameObject cannonModel;
    public AnimationCurve knockbackCurve;

    private AudioSource audioS;
    public AudioClip[] a_clips;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        fromRotation = transform.rotation;
        toRotation = Quaternion.Euler(xDegrees, 0, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
        if (fireCooling >= 0)
        {
            fireCooling -= Time.deltaTime;
        }
    }

    public void RotateY(float d)
    {
        if (xDegrees > -40 && d> 0)
        {
            direction = d;
            xDegrees -= direction * speed * friction;
            audioS.PlayOneShot(a_clips[1]);
        }
        if (xDegrees < 10 && d < 0)
        {
            direction = d;
            xDegrees -= direction * speed * friction;
            audioS.PlayOneShot(a_clips[2]);
        }
        //Debug.Log(xDegrees);
    }

    public void FireCannon()
    {
        if (fireCooling <= 0)
        {
            fireCooling = fireCooldown;
            //shotPos.rotation = transform.rotation;
            GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, shotPos.rotation) as GameObject;
            audioS.PlayOneShot(a_clips[0]);
            cannonballRB = cannonBallCopy.GetComponent<Rigidbody>();
            cannonBallCopy.GetComponent<CannonBallScript>().ct = ct;
            cannonballRB.AddForce(transform.forward * firePower);
            Destroy(cannonBallCopy, 15);
            //Instantiate(explosionEffect, shotPos.position, shotPos.rotation);
            cannonModel.transform.DOLocalMoveZ(-0.726f, 0.8f).SetEase(knockbackCurve);
        }
    }

}
