using UnityEngine;
using Unity.Cinemachine;

public class ChangeSceneInteractable : MonoBehaviour
{
    public CinemachineCamera targetCamera;
    void OnMouseDown()
    {
        PointAndClickManager.Instance.SwitchCamera(targetCamera);
    }
}
