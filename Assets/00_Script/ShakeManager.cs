using System.Collections.Generic;
using UnityEngine;
using System;

public class ShakeManager : MonoBehaviour
{
    public static ShakeManager instance;
    public Action OnShake;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            OnShake?.Invoke();
        }
    }

}
