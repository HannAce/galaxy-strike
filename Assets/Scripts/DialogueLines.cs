using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] timelineTextLines;
    private int currentline = 0;

    public void NextDialogueLine()
    {
        currentline++;
        dialogueText.text = timelineTextLines[currentline];
    }
}
