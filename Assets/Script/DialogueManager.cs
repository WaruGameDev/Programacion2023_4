using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public class Dialogue
{
    public string nameCharacter;
    public string dialogueCharacter;
    public Sprite portrait;
}
public class DialogueManager : MonoBehaviour
{
    //clase que sirve para organizar los dialogos
    public static DialogueManager instance;
    public TextMeshProUGUI dialogueText, nameCharactertext; // referencias a los textos que deben ser cambiados posteriormente
    public Image portraitCharacter;
    public List<Dialogue> dialogues; // lista de dialogos hechos con la clase serializable.
    public int indexDialogue = 0;
    public CanvasGroup cg;
    public bool isTalking;
    public PlayerPlatformController player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        isTalking = true;
        player.canMove = false;
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        dialogueText.text = dialogue.dialogueCharacter;
        nameCharactertext.text = dialogue.nameCharacter;
        portraitCharacter.sprite = dialogue.portrait;
    }

    public void NextDialogue()
    {
        indexDialogue++;
        if (indexDialogue >= dialogues.Count)
        {
            player.canMove = true;
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
            indexDialogue = 0;
            isTalking = false;
        }
        else
        {
            ShowDialogue(dialogues[indexDialogue]);
        }
        
    }

    public void AddNewDialogues(List<Dialogue> dialoguesToAdd)
    {
        dialogues.Clear();
        dialogues.AddRange(dialoguesToAdd);
    }
}
