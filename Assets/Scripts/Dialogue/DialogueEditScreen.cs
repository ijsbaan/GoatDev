using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEditScreen : EditScreen
{
    [HideInInspector]
    public Dialogue dialogue;

    public GameObject HideButton;
    public GameObject ShowButton;

    public TextMeshProUGUI TitleText;
    public TMP_InputField NameArea;
    public TMP_InputField DialogueArea;
    public GameObject OptionsList;
    public List<DialogueOption> options;
    public DialogueFileHandler fileHandler;

    public DialogueEditButton OptionButtonPrefab;

    public void ClearScreen()
    {
        // Loop through all child transforms and destroy their game objects
        for (int i = OptionsList.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(OptionsList.transform.GetChild(i).gameObject);
        }
    }

    public override void ShowEditscreen()
    {
        TitleText.text = dialogue.name;
        NameArea.text = dialogue.name;
        DialogueArea.text = dialogue.text;
        options = dialogue.options;
        ShowOptions();
    }

    public void ShowOptions()
    {
        ClearScreen();
        foreach (var option in options)
        {
            DialogueEditButton button = Instantiate(OptionButtonPrefab, OptionsList.transform);
            button.type = ButtonType.Option;
            button.TitleText.text = option.text;
            button.option = option;
        }
    }

    public void AddOption()
    {
        DialogueOption newOption = new DialogueOption();
        options.Add(newOption);
        EditScreenHandler.OptionEditScreen.option = newOption;
        EditScreenHandler.OptionEditScreen.ShowEditscreen();
        ShowOptions();
    }

    public void Submit()
    {
        dialogue.name = NameArea.text;
        dialogue.text = DialogueArea.text;
        options = dialogue.options;

        fileHandler.UpdateDialogue(dialogue);
        gameObject.SetActive(false);
        EditScreenHandler.DialogueDisplay.ShowDialogues();

    }
}
