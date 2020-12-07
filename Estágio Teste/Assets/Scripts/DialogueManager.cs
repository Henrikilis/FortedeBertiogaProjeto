using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI speakerName;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private Image speakerImage;

    [SerializeField]
    private TextMeshProUGUI btnContinue;

    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    private AlreadyInteracting alrScript;


    private int counter = 0;
    private Dialogue currentDialogue;


    void Update()
    {
        if(alrScript.isInteracting == false)
        {
            dialogueBox.gameObject.SetActive(false);
        }
    }

    public void Initiator(Dialogue dialogue)
    {
        counter = 0;
        currentDialogue = dialogue;
        NextPhrase();
    }

    public void NextPhrase()
    {
        if(currentDialogue == null)
        {
            return;
        }
        if(counter == currentDialogue.GetPhrases().Length)
        {
            dialogueBox.gameObject.SetActive(false);
            currentDialogue.DoAction();
            currentDialogue = null;
            counter = 0;
            return;
        }

        speakerName.text = currentDialogue.GetPhrases()[counter].GetSpeakerName();
        dialogueText.text = currentDialogue.GetPhrases()[counter].GetPhrase();
        btnContinue.text = currentDialogue.GetPhrases()[counter].GetButtonContinue();
        speakerImage.sprite = currentDialogue.GetPhrases()[counter].GetSpeakerImage();
        dialogueBox.gameObject.SetActive(true);
        counter++;
    }
}
