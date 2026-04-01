using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionMessage = "Interactable clicked!";
    void OnMouseDown()
    {
        PointAndClickManager.Instance.ShowInteraction(interactionMessage);
    }
   
}
