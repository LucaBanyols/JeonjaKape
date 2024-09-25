using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverStartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverStartButtonScaleAnim");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverOffStartButtonScaleAnim");
    }
}
