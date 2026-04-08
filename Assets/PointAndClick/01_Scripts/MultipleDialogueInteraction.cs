using System.Collections.Generic;
using UnityEngine;

public class MultipleDialogueInteraction : MonoBehaviour, IClickable
{
    public List<string> dialogues = new List<string>();

    public void OnClick()
    {
        PointAndClickManager.Instance.ShowTextInteraction(dialogues);
    }
}
