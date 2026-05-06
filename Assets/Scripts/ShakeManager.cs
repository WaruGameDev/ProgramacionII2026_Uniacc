using System;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{  
    public static ShakeManager Instance { get; private set; }
    public Action OnShake;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnShake?.Invoke();
        }
    }
}
