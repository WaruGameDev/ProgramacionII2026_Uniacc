using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Cinemachine;

public class PointAndClickManager : MonoBehaviour
{
    public static PointAndClickManager Instance { get; private set; }
    public CanvasGroup interactionCanvasGroup;
    public TextMeshProUGUI interactionText;
    private bool isInteractionVisible = false;
    public CinemachineCamera actualCinemachineCamera;
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
    public void ShowInteraction(string text)
    {
        if(isInteractionVisible) return;
        isInteractionVisible = true;

        interactionText.text = text;
        interactionCanvasGroup.alpha = 1f;
        interactionCanvasGroup.interactable = true;
        interactionCanvasGroup.blocksRaycasts = true;
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
