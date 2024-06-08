using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadFile : MonoBehaviour
{
    public DialogueFileHandler fileHandler;

    public int FirstDialogueId;

    DialogueList list;
    public VerticalLayoutGroup options;
    public TextMeshProUGUI DialogueTextBox;
    [HideInInspector]
    public OptionButton buttonPrefab;
    [SerializeField]
    private bool ReadAtStart;
    // Start is called before the first frame update
    void Start()
    {
        if(ReadAtStart)
        {
            list = fileHandler.ReadFile();
            GenerateDialogue(FirstDialogueId);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateDialogue(int id)
    {
        Dialogue dialogue = list.dialogues.Find(d => d.id == id);
        if (dialogue == null) return;
        DialogueTextBox.text = dialogue.text;
        ClearOptions();
        foreach (DialogueOption option in dialogue.options)
        {
            OptionButton optionbutton = Instantiate(buttonPrefab, options.transform);
            optionbutton.fileReader = this;
            optionbutton.textbox.text = option.text;
            optionbutton.NextDialogueID = int.Parse(option.next_dialogue);
        }
    }

    public void ClearOptions()
    {
        // Loop through all child transforms and destroy their game objects
        for (int i = options.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(options.transform.GetChild(i).gameObject);
        }
    }
}
