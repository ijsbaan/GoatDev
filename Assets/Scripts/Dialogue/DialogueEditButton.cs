using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ButtonType
{
    Dialogue,
    Option
}

public class DialogueEditButton : MonoBehaviour
{ 


    [HideInInspector]
    public Dialogue dialogue;
    [HideInInspector]
    public DialogueOption option;
    public ButtonType type;
    public TextMeshProUGUI TitleText;
    [HideInInspector]
    public EditScreen screen;


    public void OpenScreen()
    {
        EditScreenHandler.DialogueDisplay.DialogueDisplayList.SetActive(false);
        EditScreenHandler.DialogueDisplay.AddDialogueButton.SetActive(false);
        if (type == ButtonType.Dialogue)
        {
            EditScreenHandler.OptionEditScreen.gameObject.SetActive(false);
            screen = EditScreenHandler.DialogueEditScreen;
            OpenDialogueEditScreen();
        }
        if(type == ButtonType.Option)
        {
            EditScreenHandler.DialogueEditScreen.gameObject.SetActive(false);
            screen = EditScreenHandler.OptionEditScreen;
            OpenOptionEditScreen();
        }
    }

    private void OpenDialogueEditScreen()
    {
        screen.gameObject.SetActive(true);
        screen.GetComponent<DialogueEditScreen>().ShowButton.SetActive(true);
        screen.GetComponent<DialogueEditScreen>().HideButton.SetActive(false);
        screen.GetComponent<DialogueEditScreen>().dialogue = dialogue;
        screen.GetComponent<DialogueEditScreen>().ClearScreen();
        screen.ShowEditscreen();
    }
    private void OpenOptionEditScreen()
    {
        screen.gameObject.SetActive(true);
        screen.GetComponent<OptionEditScreen>().option = option;
        screen.ShowEditscreen();
    }
}
