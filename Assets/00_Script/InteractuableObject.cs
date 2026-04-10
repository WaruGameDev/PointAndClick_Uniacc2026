using UnityEngine;
public interface IClickeable
{
    public void OnClick();
}

public class InteractuableObject : MonoBehaviour, IClickeable
{

    public string textToShow;
    public void OnClick()
    {
        DialogueManager.instance.ShowDialogue(textToShow);
    }
}
