using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTempDialogue : MonoBehaviour
{
    public DialogueFileHandler fileHandler;
    public string FileName;
    // Start is called before the first frame update
    void Start()
    {
        fileHandler.Filename = FileName;
        fileHandler.CreateTempFile();
    }
}
