using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnim : MonoBehaviour
{
    // Scale button when hovered
    public void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    // Scale button back to normal when not hovered
    public void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
