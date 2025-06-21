using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _mouseButton = 0;

    public event Action OnLeftMouseClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            OnLeftMouseClick?.Invoke();
        }
    }
}