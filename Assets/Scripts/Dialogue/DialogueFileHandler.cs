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
    public string name;
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



    public void CreateTempFile()
    {
        DialogueList list = new();

        Dialogue exampleDialogue = new()
        {
            id = "1",
            name = "Example",
            text = "This is the text that will be said",
            options = new List<DialogueOption>
            {
                new DialogueOption{ text= "First option",next_dialogue = "Second"} ,
                new DialogueOption{ text= "another option",next_dialogue = ""}
            }
        };
        Dialogue SecondDialogue = new()
        {
            id = "2",
            name = "Second",
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

    public int GetNewID()
    {
        DialogueList list = ReadFile();
        // Find the highest existing numeric ID
        int maxId = 0;
        foreach (var dialogue in list.dialogues)
        {
            // Attempt to parse the id as an integer
            if (int.TryParse(dialogue.id, out int numericId))
            {
                // Update maxId if a higher numeric id is found
                if (numericId > maxId)
                {
                    maxId = numericId;
                }
            }
        }
        return maxId;
    }
    public void CreateNewDialogue()
    {
        DialogueList list = ReadFile();
        Dialogue dialogue = new();
        dialogue.id = GetNewID().ToString();

        list.dialogues.Add(dialogue);
        WriteFile(list);
    }

    public void UpdateDialogue(Dialogue dialogue)
    {
        DialogueList list = ReadFile();
        Dialogue oldDialogue = list.dialogues.Find(d => d.id == dialogue.id);
        oldDialogue.text = dialogue.text;
        oldDialogue.options = dialogue.options;
        WriteFile(list);
    }
    public DialogueList ReadFile()
    {
        string json = File.ReadAllText(PATH + Filename + FILEEXTENSION);
        DialogueList list = JsonUtility.FromJson<DialogueList>(json);
        return list;
    }

    public void WriteFile(DialogueList list)
    {
        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(PATH + Filename + FILEEXTENSION, json);
    }
}
