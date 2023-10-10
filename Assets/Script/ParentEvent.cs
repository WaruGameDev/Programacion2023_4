using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParentEvent : MonoBehaviour
{
    public static ParentEvent instance;
    public Action onPressButton;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPressButton?.Invoke();
        }
    }
}
