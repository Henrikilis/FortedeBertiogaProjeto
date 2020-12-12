using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraSkybox : MonoBehaviour
{
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}
