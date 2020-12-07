using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Dialogue
{
    [SerializeField]
    private DialogueText[] phrases;

    [SerializeField]
    private UnityEvent lastDialogueAction;

    //private DialogueText[] speakersName;

    public DialogueText[] GetPhrases()
    {
        return phrases;
    }

    public void DoAction()
    {
        if(lastDialogueAction != null)
        {
            lastDialogueAction.Invoke();
        }
    }
    //public DialogueText[] GetSpeakersName()
    //{
    //    return speakersName;
    //}
}
