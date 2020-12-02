using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField]
    private DialogueText[] phrases;

    //private DialogueText[] speakersName;

    public DialogueText[] GetPhrases()
    {
        return phrases;
    }

    //public DialogueText[] GetSpeakersName()
    //{
    //    return speakersName;
    //}
}
