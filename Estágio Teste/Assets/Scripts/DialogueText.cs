using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DialogueText
{
    [SerializeField]
    private string speakerName;

    [SerializeField]
    private Sprite speakerImage;

    [SerializeField]
    private bool ghost;

    [SerializeField]
    [TextArea(1,4)]
    private string phrase;

    [SerializeField]
    private string btnContinue;


    public string GetPhrase()
    {
        return phrase;
    }

    public string GetSpeakerName()
    {
        return speakerName;
    }

    public bool GetGhost()
    {
        return ghost;
    }

    public Sprite GetSpeakerImage()
    {
        return speakerImage;
    }

    public string GetButtonContinue()
    {
        return btnContinue;
    }
}
