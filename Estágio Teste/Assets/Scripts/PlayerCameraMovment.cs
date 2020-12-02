using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraMovment : MonoBehaviour
{
    CinemachineVirtualCamera playerCamera;
    Quaternion currentRotation;
    Quaternion wantedRotation;
    public float rotationSpeed;
    Button buttonMovRight;
    Button buttonMovLeft;
    AlreadyInteracting alrScript;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
        buttonMovRight = GameObject.FindGameObjectWithTag("CameraMovRight").GetComponentInChildren<Button>();
        buttonMovLeft = GameObject.FindGameObjectWithTag("CameraMovLeft").GetComponentInChildren<Button>();
        alrScript = GameObject.FindGameObjectWithTag("IsInteracting").GetComponent<AlreadyInteracting>();
        currentRotation = playerCamera.gameObject.transform.rotation;
        wantedRotation = currentRotation;
    }

    // Update is called once per frame
    void Update()
    {

        currentRotation = playerCamera.gameObject.transform.rotation;
        playerCamera.gameObject.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        Debug.Log("Rotacao Atual: " + currentRotation.eulerAngles.y + " Rotacao Desejada: " + wantedRotation.eulerAngles.y);

        if(currentRotation.eulerAngles == wantedRotation.eulerAngles && alrScript.isInteracting == false)
        {
            buttonMovRight.gameObject.SetActive(true);
            buttonMovLeft.gameObject.SetActive(true);
        }
        else if(currentRotation.eulerAngles == wantedRotation.eulerAngles && alrScript.isInteracting == true)
        {
            buttonMovRight.gameObject.SetActive(false);
            buttonMovLeft.gameObject.SetActive(false);
        }
        //else if (currentRotation.eulerAngles == wantedRotation.eulerAngles && buttonMovLeft.gameObject.activeSelf == false)
        //{
        //    buttonMovLeft.gameObject.SetActive(true);
        //}
    }

    public void ButtonClickToMoveCameraRight()
    {
        buttonMovRight.gameObject.SetActive(false);
        buttonMovLeft.gameObject.SetActive(false);
        //currentRotation = playerCamera.gameObject.transform.rotation;
        wantedRotation = Quaternion.Euler(0, currentRotation.eulerAngles.y + 90f, 0);

        //playerCamera.gameObject.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
    }

    public void ButtonClickToMoveCameraLeft()
    {
        buttonMovLeft.gameObject.SetActive(false);
        buttonMovRight.gameObject.SetActive(false);
        //currentRotation = playerCamera.gameObject.transform.rotation;
        wantedRotation = Quaternion.Euler(0, currentRotation.eulerAngles.y - 90f, 0);
    }
}
