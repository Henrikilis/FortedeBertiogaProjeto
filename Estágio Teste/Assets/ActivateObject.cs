using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject activate;

    private void OnEnable()
    {
        activate.SetActive(true);
    }
}
