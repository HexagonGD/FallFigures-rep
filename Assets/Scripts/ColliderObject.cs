using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderObject : MonoBehaviour
{
    public event Action MouseDownEvent;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            MouseDownEvent?.Invoke();
    }
}