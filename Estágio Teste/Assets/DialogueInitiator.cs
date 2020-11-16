using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueM;
    [SerializeField]
    private Dialogue dialogue;


    public void Initiator()
    {
        if(dialogueM == null)
        {
            return;
        }

        dialogueM.Initiator(dialogue);
    }
}
