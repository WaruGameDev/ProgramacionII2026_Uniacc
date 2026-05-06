using UnityEngine;
using DG.Tweening;

public class ShakeOnClick : MonoBehaviour
{
    private bool isSubscribed = false;
    
    public void Shake()
    {
        transform.DOShakePosition(0.5f, 1f, 10, 90, false, true);
    }
    void OnMouseDown()
    {
        if(isSubscribed)
        {
            ShakeManager.Instance.OnShake -= Shake;
            isSubscribed = false;
        }
        else if(!isSubscribed)
        {
            ShakeManager.Instance.OnShake += Shake;
            isSubscribed = true;
        }
    }
}
