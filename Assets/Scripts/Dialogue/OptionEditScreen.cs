using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionEditScreen : EditScreen
{
    [HideInInspector]
    public Dialogue dialogue;
    [HideInInspector]
    public DialogueOption option;
    [SerializeField]
    private DialogueFileHandler fileHandler;
    public TextMeshProUGUI TitleText;
    public TMP_InputField DialogueArea;
    public TMP_Dropdown Next_dialogue;

    public override void ShowEditscreen()
    {
        TitleText.text = option.text;
        DialogueArea.text = option.text;
        var dialogues = fileHandler.ReadFile().dialogues;
        Next_dialogue.ClearOptions();
        foreach (var dialogue in dialogues)
        {
            DropDownValue option = new DropDownValue();
            option.text = dialogue.name;
            option.Value = dialogue.id;
            Next_dialogue.options.Add(option);
        }
        Next_dialogue.value = int.Parse(option.next_dialogue);
    }

    public void CloseScreen()
    {
        EditScreenHandler.DialogueEditScreen.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Submit()
    {
        option.text = DialogueArea.text;
        option.next_dialogue = Next_dialogue.value.ToString();
        Debug.Log(Next_dialogue.value.ToString());
        CloseScreen();
    }
}
