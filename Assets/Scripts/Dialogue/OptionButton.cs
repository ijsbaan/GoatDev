using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public Button button;
    public int NextDialogueID;

    public ReadFile fileReader;

    public void SwapToNextDialogue()
    {
        fileReader.GenerateDialogue(NextDialogueID);
    }
}
