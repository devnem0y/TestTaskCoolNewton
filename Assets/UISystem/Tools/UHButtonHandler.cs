using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UHButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] [Range(-1, 1)] private int _axis;
    
    public event Action<int> Click;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Click?.Invoke(_axis);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Click?.Invoke(0);
    }
}
