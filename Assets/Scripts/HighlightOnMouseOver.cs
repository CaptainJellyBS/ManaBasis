using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Renderer[] renderers;
    public bool highlightObject = true;
    public bool highlightChildren = false;
    public bool setCursor = true;
    private void Start()
    {
        if (highlightObject)
        {
            if (!highlightChildren) { renderers = GetComponents<Renderer>(); }
            else { renderers = GetComponentsInChildren<Renderer>(); }
            foreach (Renderer r in renderers)
            {
                r.material.EnableKeyword("_EMISSION");
            }
        }
    }

    private void OnMouseEnter()
    {       
        if (setCursor) { GameManager.Instance.SetCursor(CursorState.overInteractible); }
        if (!highlightObject) { return; }
        foreach (Renderer r in renderers)
        {
            r.material.SetColor("_EmissionColor", new Color(0.25f,0.25f,0.25f,1.0f));
        }
    }

    private void OnMouseExit()
    {
        if (setCursor) { GameManager.Instance.SetCursor(CursorState.normal); }
        
        if (!highlightObject) { return; }
        foreach (Renderer r in renderers)
        {
            r.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (setCursor) { GameManager.Instance.SetCursor(CursorState.overInteractible); }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (setCursor) { GameManager.Instance.SetCursor(CursorState.normal); }
    }
}
