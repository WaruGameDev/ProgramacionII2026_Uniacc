using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MultipleDialogueInteraction : MonoBehaviour, IClickable
{
    public List<DialogueWithEvent> dialogues = new List<DialogueWithEvent>();

    public void OnClick()
    {
        PointAndClickManager.Instance.ShowTextInteraction(dialogues);
    }
}
