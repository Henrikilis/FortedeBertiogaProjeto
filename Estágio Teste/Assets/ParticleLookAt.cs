using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLookAt: MonoBehaviour
{

    public GameObject target;

    void Start()
    {
        
    }
    void Update()
    {
        transform.LookAt(target.transform.position);
    }
}
