using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isPlayerInZone;
    public List<Dialogue> npcDialogues;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            DialogueManager.instance.AddNewDialogues(npcDialogues);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }

    private void Update()
    {
        if (isPlayerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DialogueManager.instance.isTalking)
                {
                    DialogueManager.instance.NextDialogue();
                }
                else
                {
                    DialogueManager.instance.ShowDialogue(DialogueManager.instance.dialogues[0]);
                }
                
            }
        }
    }
}
