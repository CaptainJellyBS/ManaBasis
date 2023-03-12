using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CursorState { normal, overInteractible, overDraggable};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UnityEvent deathEvents, winEvents;
    public bool isDragging;

    public Texture2D normalCursor, interactibleCursor, draggableCursor;
	
    private void Awake()
    {
        Instance = this;
    }

    #region ManaBasic Functionality
    public void Die()
    {
        deathEvents.Invoke();
    }

    public void Win()
    {
        winEvents.Invoke();
    }
	
	 public void SetCursor(CursorState state)
    {
        if (isDragging) { return; }
        switch(state)
        {
            case CursorState.normal: Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto); break;
            case CursorState.overInteractible: Cursor.SetCursor(interactibleCursor, Vector2.zero, CursorMode.Auto); break;
            case CursorState.overDraggable: Cursor.SetCursor(draggableCursor, new Vector2(16,16), CursorMode.Auto); break;
            default: Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto); break;
        }
    }
    #endregion

    #region debug

    #endregion
}
