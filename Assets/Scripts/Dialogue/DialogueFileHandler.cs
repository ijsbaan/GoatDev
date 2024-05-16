using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string id;
    public string text;
    public string next_dialogue;
}
[System.Serializable]
public class Dialogue
{
    public string id;
    public string text;
    public List<DialogueOption> options;
}

[System.Serializable]
public class DialogueList
{
    public List<Dialogue> dialogues = new();
}

public class DialogueFileHandler : MonoBehaviour
{
    [HideInInspector]
    public string Filename;
    public static string PATH = "Assets/Dialogue/";
    public static string FILEEXTENSION = ".dlg";



    public void CreateFile()
    {
        DialogueList list = new();

        Dialogue exampleDialogue = new()
        {
            id = "Example",
            text = "This is the text that will be said",
            options = new List<DialogueOption>
            {
                new DialogueOption{ text= "First option",next_dialogue = "Second"} ,
                new DialogueOption{ text= "another option",next_dialogue = ""}
            }
        };
        Dialogue SecondDialogue = new()
        {
            id = "Second",
            text = "This is the text that will be said",
            options = new List<DialogueOption>
            {
            }
        };

        list.dialogues.Add(exampleDialogue);
        list.dialogues.Add(SecondDialogue);
        string json = JsonUtility.ToJson(list,true);
        File.WriteAllText(PATH + Filename + FILEEXTENSION, json);
    }

    public DialogueList ReadFile()
    {
        string json = File.ReadAllText(PATH + Filename + FILEEXTENSION);
        DialogueList list = JsonUtility.FromJson<DialogueList>(json);
        return list;
    }
}
