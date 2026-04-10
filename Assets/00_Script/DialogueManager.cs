using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI textDialogue;

    void Awake()
    {
        instance = this;
    }

    public void ShowDialogue(string dialogue)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        textDialogue.text = dialogue;
    }


}
