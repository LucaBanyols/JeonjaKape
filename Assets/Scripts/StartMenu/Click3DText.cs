using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Click3DText : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onClick;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(name + " Game Object Clicked!", this);
        onClick.Invoke();
    }
}
