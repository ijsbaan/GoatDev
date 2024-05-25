using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditScreenHandler : MonoBehaviour
{
    public static DialogueDisplay DialogueDisplay;
    public static DialogueEditScreen DialogueEditScreen;
    public static OptionEditScreen OptionEditScreen;

    public DialogueDisplay dialogueDisplay;
    public DialogueEditScreen dialogueEditScreen;
    public OptionEditScreen optionEditScreen;
    private void Awake()
    {
        DialogueDisplay = dialogueDisplay;
        DialogueEditScreen = dialogueEditScreen;
        OptionEditScreen = optionEditScreen;
        dialogueEditScreen.gameObject.SetActive(false);
        optionEditScreen.gameObject.SetActive(false);
    }
}
