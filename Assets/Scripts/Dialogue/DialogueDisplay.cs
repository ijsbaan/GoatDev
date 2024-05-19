using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public DialogueEditButton DialogueEditButtonPrefab;
    public DialogueFileHandler fileHandler;
    public GameObject DialogueDisplayList;
    public GameObject AddDialogueButton;

    public void Start()
    {
        ShowDialogues();
    }
    public void ClearDialogueList()
    {
        // Loop through all child transforms and destroy their game objects
        for (int i = DialogueDisplayList.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(DialogueDisplayList.transform.GetChild(i).gameObject);
        }
    }

    public void ShowDialogues()
    {
        DialogueList dialogueList = fileHandler.ReadFile();
        foreach (var dialogue in dialogueList.dialogues)
        {
            DialogueEditButton button = Instantiate(DialogueEditButtonPrefab, DialogueDisplayList.transform);
            button.type = ButtonType.Dialogue;
            button.TitleText.text = dialogue.name;
            button.dialogue = dialogue;
        }
    }
}
