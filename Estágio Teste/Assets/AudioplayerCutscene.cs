using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioplayerCutscene : MonoBehaviour
{
    public GameObject sfx_ghost;
    public GameObject sfx_snoring;

    public void GhostSFX()
    {
        sfx_ghost.SetActive(true);
    }

    public void SnoringSFX()
    {
        sfx_snoring.SetActive(true);
    }



}
