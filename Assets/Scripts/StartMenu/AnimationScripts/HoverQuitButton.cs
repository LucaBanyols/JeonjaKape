using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverQuitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverQuitButtonScaleAnim");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverOffQuitButtinScaleAnim");
    }
}
