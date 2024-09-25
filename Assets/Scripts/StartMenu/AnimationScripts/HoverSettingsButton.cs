using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverSettingsButtonScaleAnim");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("HoverOffSettingsButtonScaleAnim");
    }
}
