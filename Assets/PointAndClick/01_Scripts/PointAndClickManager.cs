using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Cinemachine;
using System.Collections.Generic;
using UnityEngine.Events;
[System.Serializable]
public class DialogueWithEvent
{
    [TextArea(3, 10)]
    public string dialogue;
    [Space(10)]
    public UnityEvent onDialogueComplete;

    public DialogueWithEvent(string dialogue, UnityEvent onDialogueComplete = null)
    {
        this.dialogue = dialogue;
        this.onDialogueComplete = onDialogueComplete;
    }
}

public class PointAndClickManager : MonoBehaviour
{
    public static PointAndClickManager Instance { get; private set; }
    public CanvasGroup interactionCanvasGroup;
    public TextMeshProUGUI interactionText;
    public bool isInteractionVisible = false;
    public CinemachineCamera actualCinemachineCamera;

    public List<DialogueWithEvent> actualDialogues = new List<DialogueWithEvent>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;           
        }
    }
    void Start()
    {
        HideInteraction();
    }
    public void ShowInteraction(string text)
    {
        if(isInteractionVisible) return;
        isInteractionVisible = true;

        interactionText.text = text;
        interactionCanvasGroup.alpha = 1f;
        interactionCanvasGroup.interactable = true;
        interactionCanvasGroup.blocksRaycasts = true;
    }
    public void ShowTextInteraction(List<DialogueWithEvent> dialogueWithEvents)
    {
        if(isInteractionVisible) return;
        isInteractionVisible = true;
        actualDialogues.Clear();
        actualDialogues.AddRange(dialogueWithEvents);

        interactionText.text = actualDialogues[0].dialogue;
        actualDialogues[0].onDialogueComplete?.Invoke();

        interactionCanvasGroup.alpha = 1f;
        interactionCanvasGroup.interactable = true;
        interactionCanvasGroup.blocksRaycasts = true;
    }

    public void NextTextInteraction()
    {
        if (actualDialogues.Count == 0) return;

        actualDialogues.RemoveAt(0);

        if (actualDialogues.Count > 0)
        {
            interactionText.text = actualDialogues[0].dialogue;
            actualDialogues[0].onDialogueComplete?.Invoke();
        }
        else
        {
            HideInteraction();
        }
    }
    public void HideInteraction()
    {
        isInteractionVisible = false;
        interactionCanvasGroup.alpha = 0f;
        interactionCanvasGroup.interactable = false;
        interactionCanvasGroup.blocksRaycasts = false;
    }
    public void SwitchCamera(CinemachineCamera newCamera)
    {
        if(isInteractionVisible) return;
        if (actualCinemachineCamera != null)
        {
            actualCinemachineCamera.Priority = 0;
        }
        newCamera.Priority = 10;
        actualCinemachineCamera = newCamera;
    }
}
